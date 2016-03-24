using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Geography.CodeFirst.Data;
using Geography.CodeFirst.Data.Migrations;
using Geography.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Country = Geography.Data.Country;
using Country2 = Geography.CodeFirst.Data.Country;

namespace Geography.ConsoleClient
{
    public class ConsoleClient
    {
        public static void Main()
        {
            using (var db = new GeographyEntities())
            {
                //ExtractRiversToJson(db);

                //ExtractCountriesToXml(db);

                //var riverModels = ReadRiversFromXml(db);
                //db.Rivers.AddRange(riverModels);
                //db.SaveChanges();

                RiversByCountryQueries(db);
            }

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GeographyCodeFirstDb, Configuration>());
            //using (var db = new GeographyCodeFirstDb())
            //{
            //    var mountains = JArray.Parse(File.ReadAllText("mountains.json"));
            //    foreach (var mountain in mountains)
            //    {
            //        try
            //        {
            //            AddMountain(mountain, db);
            //            Console.WriteLine("Mountain {0} imported", mountain["mountainName"]);
            //        }
            //        catch (ArgumentException e)
            //        {
            //            Console.WriteLine("Error: " + e.Message);
            //        }
            //    }
            //}
        }

        private static void AddMountain(JToken mountain, GeographyCodeFirstDb db)
        {
            var mountainName = mountain["mountainName"];
            if (mountainName == null)
            {
                throw new ArgumentException("Missing mountain name");
            }

            var newMountain = new Mountain {Name = mountainName.ToString()};

            var countries = mountain["countries"];
            if (countries != null)
            {
                foreach (var countryName in countries.Select(c => c.ToString()))
                {
                    var countryCode = countryName.Substring(0, 2).ToUpper();
                    var country = db.Countries.Find(countryCode) ?? new Country2 {Name = countryName, CountryCode = countryCode};
                    newMountain.Countries.Add(country);
                }
            }

            var peaks = mountain["peaks"];
            if (peaks != null)
            {
                foreach (var peak in peaks.Select(p => new { Name = p["peakName"], Elevation = p["elevation"] }))
                {
                    if (peak.Name == null)
                    {
                        throw new ArgumentException("Missing peak name");
                    }

                    if (peak.Elevation == null)
                    {
                        throw new ArgumentException("Missing peak elevation");
                    }

                    newMountain.Peaks.Add(new Peak {Name = peak.Name.ToString(), Elevation = peak.Elevation.Value<int>()});
                }
            }

            db.Mountains.Add(newMountain);
            db.SaveChanges();
        }

        private static void RiversByCountryQueries(GeographyEntities db)
        {
            var resultXml = new XElement("results");
            var queries = XDocument.Load("rivers-query.xml").Descendants("query");
            foreach (var query in queries)
            {
                var maxResults = int.MaxValue;
                if (query.Attribute("max-results") != null)
                {
                    maxResults = int.Parse(query.Attribute("max-results").Value);
                }
                
                var countryNames = query.Descendants("country").Select(c => c.Value);
                var riversQuery = db.Rivers
                    .Where(r => r.Countries.Any(c => countryNames.Contains(c.CountryName)))
                    .OrderBy(r => r.RiverName)
                    .Select(r => r.RiverName);

                var riversXml = new XElement("rivers");
                var rivers = riversQuery.Take(maxResults).ToList();
                foreach (var river in rivers)
                {
                    riversXml.Add(new XElement("river", river));
                }

                riversXml.SetAttributeValue("total-count", riversQuery.Count());
                riversXml.SetAttributeValue("listed-count", rivers.Count);
                resultXml.Add(riversXml);
            }

            new XDocument(resultXml).Save("result.xml");
        }

        private static void ExtractCountriesToXml(GeographyEntities db)
        {
            var countries = db.Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    c.CountryName,
                    Monasteries = c.Monasteries.OrderBy(m => m.Name).Select(m => m.Name)
                });

            var xml = new XElement("monasteries");
            foreach (var country in countries)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.SetAttributeValue("name", country.CountryName);
                xml.Add(xmlCountry);

                foreach (var monastery in country.Monasteries)
                {
                    xmlCountry.Add(new XElement("monastery", monastery));
                }
            }

            new XDocument(xml).Save("countries.xml");
        }

        private static void ExtractRiversToJson(GeographyEntities db)
        {
            var rivers = db.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    r.RiverName,
                    r.Length,
                    Countries = r.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName)
                });

            var json = JsonConvert.SerializeObject(rivers);
            File.WriteAllText("rivers.json", json);
        }

        private static IEnumerable<River> ReadRiversFromXml(GeographyEntities db)
        {
            var xml = XDocument.Load("rivers.xml");
            var riverNodes = xml.Descendants("river");
            var riverModels = new List<River>();
            foreach (var river in riverNodes)
            {
                int? drainageArea = null;
                var drainageAreaNode = river.Descendants("drainage-area").SingleOrDefault();
                if (drainageAreaNode != null)
                {
                    drainageArea = int.Parse(drainageAreaNode.Value);
                }

                int? averageDischarge = null;
                var averageDischargeNode = river.Descendants("average-discharge").SingleOrDefault();
                if (averageDischargeNode != null)
                {
                    averageDischarge = int.Parse(averageDischargeNode.Value);
                }

                var countries = new List<Country>();
                var countryNames = river.Descendants("country").Select(c => c.Value);
                foreach (var countryName in countryNames)
                {
                    var country = db.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    if (country == null)
                    {
                        country = new Country { CountryName = countryName };
                        db.Countries.Add(country);
                        db.SaveChanges();
                    }

                    countries.Add(country);
                }

                riverModels.Add(new River
                {
                    RiverName = river.Descendants("name").Single().Value,
                    Length = int.Parse(river.Descendants("length").Single().Value),
                    Outflow = river.Descendants("outflow").Single().Value,
                    AverageDischarge = averageDischarge,
                    DrainageArea = drainageArea,
                    Countries = countries
                });
            }

            return riverModels;
        }
    }
}

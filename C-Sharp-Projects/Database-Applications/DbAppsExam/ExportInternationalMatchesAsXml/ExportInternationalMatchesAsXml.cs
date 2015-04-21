namespace ExportInternationalMatchesAsXml
{
    using System.Linq;
    using System.Xml.Linq;
    using Football.Data.DbFirst;

    public class ExportInternationalMatchesAsXml
    {
        public static void Main()
        {
            using (var db = new FootballEntities())
            {
                var internationalMatches = db.InternationalMatches
                    .OrderBy(m => m.MatchDate)
                    .ThenBy(m => m.HomeCountry.CountryName)
                    .ThenBy(m => m.AwayCountry.CountryName)
                    .Select(m => new
                    {
                        m.HomeCountryCode,
                        m.AwayCountryCode,
                        HomeCountry = m.HomeCountry.CountryName,
                        AwayCountry = m.AwayCountry.CountryName,
                        m.MatchDate,
                        m.League.LeagueName,
                        Score = (m.HomeGoals != null && m.AwayGoals != null) ? m.HomeGoals + "-" + m.AwayGoals : null
                    })
                    .ToList();

                var resultXml = new XElement("matches");
                foreach (var match in internationalMatches)
                {
                    var matchXml = new XElement("match");

                    var homeCountryXml = new XElement("home-country", match.HomeCountry);
                    homeCountryXml.SetAttributeValue("code", match.HomeCountryCode);
                    matchXml.Add(homeCountryXml);

                    var awayCountryXml = new XElement("away-country", match.AwayCountry);
                    awayCountryXml.SetAttributeValue("code", match.AwayCountryCode);
                    matchXml.Add(awayCountryXml);

                    if (match.Score != null)
                    {
                        matchXml.Add(new XElement("score", match.Score));
                    }

                    if (match.LeagueName != null)
                    {
                        matchXml.Add(new XElement("league", match.LeagueName));
                    }

                    if (match.MatchDate != null)
                    {
                        if (match.MatchDate.Value.TimeOfDay.Ticks != 0)
                        {
                            matchXml.SetAttributeValue("date-time", match.MatchDate.Value.ToString("dd-MMM-yyyy hh:mm"));
                        }
                        else
                        {
                            matchXml.SetAttributeValue("date", match.MatchDate.Value.ToString("dd-MMM-yyyy"));
                        }
                    }

                    resultXml.Add(matchXml);
                }

                new XDocument(resultXml).Save("../../../Helper.Files/international-matches.xml");
            }
        }
    }
}

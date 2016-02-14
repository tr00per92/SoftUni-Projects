namespace XmlParsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Xsl;

    public class Program
    {
        private const string CatalogLocation = "..\\..\\catalog.xml";

        public static void Main()
        {
            //Console.WriteLine("Albums: " + string.Join(", ", ExtractAlbumNames()));
            //Console.WriteLine("Artists: " + string.Join(", ", ExtractArtistsAlphabetically()));

            //foreach (var pair in ExtractArtistsAndAlbumsNumber())
            //{
            //    Console.WriteLine("{0} -> {1} album(s)", pair.Key, pair.Value);
            //}

            //foreach (var pair in ExtractArtistsAndAlbumsNumberXpath())
            //{
            //    Console.WriteLine("{0} -> {1} album(s)", pair.Key, pair.Value);
            //}
            
            //ExtractCheapAlbums();

            //foreach (var pair in ExtractOldAlbumsWithPriceXpath())
            //{
            //    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            //}

            //foreach (var pair in ExtractOldAlbumsWithPriceLinq2Xml())
            //{
            //    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            //}

            //ExtractDirectoryContent("C:\\Temp");
            //ExtractDirectoryContentXelement("C:\\Temp");

            //ValidateXml(CatalogLocation, "..\\..\\catalog.xsd");

            //TransformXmlToHtml(CatalogLocation, "..\\..\\catalog.html", "..\\..\\catalog-xml2html.xsl");
        }

        private static IEnumerable<string> ExtractAlbumNames()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(CatalogLocation);

            var albumNames = new List<string>();
            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                if (node.Name == "album")
                {
                    albumNames.Add(node.Attributes["name"].Value);
                }
            }

            return albumNames;
        }

        private static IEnumerable<string> ExtractArtistsAlphabetically()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(CatalogLocation);

            var artists = new SortedSet<string>();
            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                if (node.Name == "album")
                {
                    artists.Add(node.Attributes["artist"].Value);
                }
            }

            return artists;
        }

        private static IDictionary<string, int> ExtractArtistsAndAlbumsNumber()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(CatalogLocation);

            var artistsAndAlbums = new Dictionary<string, int>();
            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                if (node.Name == "album")
                {
                    var artist = node.Attributes["artist"].Value;
                    if (!artistsAndAlbums.ContainsKey(artist))
                    {
                        artistsAndAlbums.Add(artist, 0);
                    }

                    artistsAndAlbums[artist]++;
                }
            }

            return artistsAndAlbums;
        }

        private static IDictionary<string, int> ExtractArtistsAndAlbumsNumberXpath()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(CatalogLocation);

            var artistsAndAlbums = new Dictionary<string, int>();
            foreach (var artist in ExtractArtistsAlphabetically())
            {
                var albums = xmlDocument.SelectNodes(string.Format("/albums/album[@artist='{0}']", artist));
                artistsAndAlbums.Add(artist, albums.Count);
            }

            return artistsAndAlbums;
        }

        private static void ExtractCheapAlbums()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(CatalogLocation);
            var root = xmlDocument.DocumentElement;

            var expensiveAlbums = new List<XmlNode>();
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "album" && decimal.Parse(node.Attributes["price"].Value) > 20)
                {
                    expensiveAlbums.Add(node);
                }
            }

            foreach (XmlNode node in expensiveAlbums)
            {
                root.RemoveChild(node);
            }

            xmlDocument.Save("..//..//cheap-albums-catalog.xml");
        }

        private static IDictionary<string, decimal> ExtractOldAlbumsWithPriceXpath()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(CatalogLocation);

            var oldAlbumsWithPrice = new Dictionary<string, decimal>();
            var oldAlbums = xmlDocument.SelectNodes(string.Format("/albums/album[@year<'{0}']", DateTime.Now.Year - 5));
            foreach (XmlNode album in oldAlbums)
            {
                oldAlbumsWithPrice.Add(album.Attributes["name"].Value, decimal.Parse(album.Attributes["price"].Value));
            }

            return oldAlbumsWithPrice;
        }

        private static IDictionary<string, decimal> ExtractOldAlbumsWithPriceLinq2Xml()
        {
            var xmlDocument = XDocument.Load(CatalogLocation);

            var oldAlbumsWithPrice = xmlDocument
                .Descendants("album")
                .Where(album => int.Parse(album.Attribute("year").Value) < DateTime.Now.Year - 5)
                .ToDictionary(a => a.Attribute("name").Value, a => decimal.Parse(a.Attribute("price").Value));

            return oldAlbumsWithPrice;
        }

        private static void ExtractDirectoryContent(string path)
        {
            var name = path.Split('\\').Last().ToLower() + " content.xml";
            using (var writer = new XmlTextWriter("..\\..\\" + name, Encoding.GetEncoding("utf-8")))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("root-dir");
                writer.WriteAttributeString("path", path);

                AddFilesToXmlWriter(new DirectoryInfo(path), writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void AddFilesToXmlWriter(DirectoryInfo root, XmlWriter writer)
        {
            try
            {
                foreach (var file in root.GetFiles())
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", file.Name);
                    writer.WriteEndElement();
                }

                foreach (var dir in root.GetDirectories())
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("name", dir.Name);
                    AddFilesToXmlWriter(dir, writer);
                    writer.WriteEndElement();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Access Denied
            }
        }

        private static void ExtractDirectoryContentXelement(string path)
        {
            var booksXml = new XElement("root-dir");
            booksXml.SetAttributeValue("path", path);

            AddFilesToXelement(new DirectoryInfo(path), booksXml);

            var name = path.Split('\\').Last().ToLower() + " content.xml";
            booksXml.Save("..\\..\\" + name);
        }

        private static void AddFilesToXelement(DirectoryInfo root, XContainer xElement)
        {
            try
            {
                foreach (var file in root.GetFiles())
                {
                    var fileElement = new XElement("file");
                    fileElement.SetAttributeValue("name", file.Name);
                    xElement.Add(fileElement);
                }

                foreach (var dir in root.GetDirectories())
                {
                    var dirElement = new XElement("dir");
                    dirElement.SetAttributeValue("name", dir.Name);
                    AddFilesToXelement(dir, dirElement);
                    xElement.Add(dirElement);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Access Denied
            }
        }
        
        private static void ValidateXml(string xmlPath, string schemaPath)
        {
            var schemas = new XmlSchemaSet();
            schemas.Add("", schemaPath);
            var xml = XDocument.Load(xmlPath);
            var valid = true;
            xml.Validate(schemas, (o, e) =>
            {
                Console.WriteLine(e.Message);
                valid = false;
            });

            if (valid)
            {
                Console.WriteLine("Validation successful.");
            }
        }

        private static void TransformXmlToHtml(string xmlPath, string htmlPath, string xslPath)
        {
            var xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            xslt.Transform(xmlPath, htmlPath);
        }
    }
}

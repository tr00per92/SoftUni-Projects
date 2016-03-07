namespace ProcessingJson
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Web.UI;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        private const string FeedPath = "../../feed.xml";

        public static void Main()
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile("https://softuni.bg/Feed/News", FeedPath);
            }

            var json = JsonConvert.SerializeXNode(XDocument.Load(FeedPath));
            var jsonObject = JObject.Parse(json);

            var items = jsonObject["rss"]["channel"]["item"];
            var itemTitles = items.Select(x => x["title"]);
            foreach (var title in itemTitles)
            {
                Console.WriteLine(title);
            }

            var news = JsonConvert.DeserializeObject<IEnumerable<News>>(items.ToString());
            SaveNewsAsHtml(news, "../../news.html");
        }

        private static void SaveNewsAsHtml(IEnumerable<News> news, string htmlPath)
        {
            using (var streamWriter = new StreamWriter(htmlPath))
            {
                using (var writer = new HtmlTextWriter(streamWriter))
                {
                    writer.Write("<!DOCTYPE html>");
                    writer.RenderBeginTag(HtmlTextWriterTag.Html);
                    writer.Write("<head><meta charset=\"UTF-8\"></head>");

                    writer.RenderBeginTag(HtmlTextWriterTag.Body);
                    foreach (var item in news)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        writer.RenderBeginTag(HtmlTextWriterTag.H2);
                        writer.Write(item.Title);
                        writer.RenderEndTag();

                        writer.AddAttribute(HtmlTextWriterAttribute.Href, item.Link);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write(item.Link);
                        writer.RenderEndTag();

                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.Write(item.Description);
                        writer.RenderEndTag();

                        writer.RenderEndTag();
                    }

                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
            }
        }
    }
}

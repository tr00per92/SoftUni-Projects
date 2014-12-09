using System;
using System.IO;
using DocumentSystem.Utils;

namespace DocumentSystem.Structure
{
    public class Hyperlink : CompositeElement
    {
        public Hyperlink(string url)
        {
            this.Url = url;
        }

        public Hyperlink(string url, string text)
        {
            this.Url = url;
            this.Add(new TextElement(text));
        }

        public string Url { get; set; }

        public override void RenderHtml(TextWriter writer)
        {
            writer.Write("<a href='{0}'>", this.Url.HtmlEncode());
            if (this.ChildElements.Count > 0)
            {
                base.RenderHtml(writer);
            }
            else
            {
                writer.Write(this.Url.HtmlEncode());
            }

            writer.Write("</a>");
        }

        public override void RenderText(TextWriter writer)
        {
            writer.Write("[url={0}]", this.Url);
            base.RenderText(writer);
            writer.Write("[/url]");
        }
    }
}

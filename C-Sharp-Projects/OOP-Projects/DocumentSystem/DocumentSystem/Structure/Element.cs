using System;
using System.IO;
using DocumentSystem.Renderers;

namespace DocumentSystem.Structure
{
    public abstract class Element : IHtmlRenderer, ITextRenderer
    {
        public Element Parent { get; set; }

        public string AsHTML
        {
            get
            {
                StringWriter writer = new StringWriter();
                this.RenderHtml(writer);
                return writer.ToString();
            }
        }

        public string AsText
        {
            get
            {
                StringWriter writer = new StringWriter();
                this.RenderText(writer);
                return writer.ToString();
            }
        }

        public override string ToString()
        {
            return this.AsText;
        }

        public abstract void RenderHtml(TextWriter writer);

        public abstract void RenderText(TextWriter writer);
    }
}

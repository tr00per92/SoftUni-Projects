using System;
using System.IO;

namespace DocumentSystem.Renderers
{
    public interface IHtmlRenderer
    {
        void RenderHtml(TextWriter writer);
    }
}

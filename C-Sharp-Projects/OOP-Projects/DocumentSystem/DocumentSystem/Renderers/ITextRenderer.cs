using System;
using System.IO;

namespace DocumentSystem.Renderers
{
    public interface ITextRenderer
    {
        void RenderText(TextWriter writer);
    }
}

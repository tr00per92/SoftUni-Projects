using System;
using System.Collections.Generic;
using System.IO;

namespace DocumentSystem.Structure
{
    public class CompositeElement : Element
    {
        public CompositeElement()
        {
            this.ChildElements = new List<Element>();
        }

        public CompositeElement(params Element[] elements)
            : this()
        {
            this.Add(elements);
        }

        protected IList<Element> ChildElements { get; set; }

        public CompositeElement Add(params Element[] elements)
        {
            foreach (var element in elements)
            {
                CheckForLoop(this, element);
                element.Parent = this;
                this.ChildElements.Add(element);
            }

            return this;
        }

        public override void RenderHtml(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderHtml(writer);
            }
        }

        public override void RenderText(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderText(writer);
            }
        }

        private void CheckForLoop(Element parent, Element child)
        {
            while (parent != null)
            {
                if (parent == child)
                {
                    throw new InvalidOperationException("Loops in the document structure are not allowed.");
                }

                parent = parent.Parent;
            }
        }
    }
}

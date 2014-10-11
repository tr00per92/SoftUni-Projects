using System;
using System.Collections.Generic;
using System.Text;

namespace _04_HTMLDispatcher
{
    class ElementBuilder
    {
        // fields
        private string name;
        private string content = string.Empty;
        private IDictionary<string, string> attributes = new Dictionary<string, string>();

        // constructor
        public ElementBuilder(string elementName, bool selfClosing = false)
        {
            this.Name = elementName;
            this.SelfClosing = selfClosing;
        }

        // properties
        private string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of the element cannot be empty");
                }
                this.name = value;
            }
        }
        private bool SelfClosing { get; set; }

        // methods
        public void AddContent(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("The content cannot be empty");
            }
            if (this.SelfClosing)
            {
                throw new ArgumentException("Self closing elements cannot have content");
            }
            this.content = content;
        }
        public void AddAttribute(string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The attribute name and the attribute value cannot be empty");
            }
            this.attributes[attribute] = value;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            // opening the tag
            result.AppendFormat("<{0}", this.name);
            // adding all the attributes
            foreach (var pair in this.attributes)
            {
                result.AppendFormat(" {0}=\"{1}\"", pair.Key, pair.Value);
            }
            // closing the tag
            if (this.SelfClosing)
            {
                result.Append(" />");
            }
            else
            {
                result.AppendFormat(">{0}</{1}>", this.content, this.name);
            }
            // returning result
            return result.ToString();
        }

        // operators
        public static string operator *(ElementBuilder element, int number)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                result.Append(element.ToString());
            }
            return result.ToString();
        }
        public static string operator *(int number, ElementBuilder element)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                result.Append(element.ToString());
            }
            return result.ToString();
        }
    }
}

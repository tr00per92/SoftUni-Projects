using System;

namespace _04_HTMLDispatcher
{
    static class HTMLDispatcher
    {
        public static ElementBuilder CreateImage(string source, string alt, string title)
        {
            ElementBuilder result = new ElementBuilder("img", true);
            result.AddAttribute("src", source);
            result.AddAttribute("alt", alt);
            result.AddAttribute("title", title);
            return result;
        }
        public static ElementBuilder CreateURL(string url, string title, string text)
        {
            ElementBuilder result = new ElementBuilder("a");
            result.AddContent(text);
            result.AddAttribute("title", title);
            result.AddAttribute("href", url);
            return result;
        }
        public static ElementBuilder CreateInput(string type, string name, string value)
        {
            ElementBuilder result = new ElementBuilder("input", true);
            result.AddAttribute("type", type);
            result.AddAttribute("name", name);
            result.AddAttribute("value", value);
            return result;
        }
    }
}

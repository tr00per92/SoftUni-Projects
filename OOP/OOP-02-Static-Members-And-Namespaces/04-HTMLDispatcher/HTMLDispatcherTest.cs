using System;

namespace _04_HTMLDispatcher
{
    class HTMLDispatcherTest
    {
        static void Main()
        {
            ElementBuilder testElement = new ElementBuilder("a");
            Console.WriteLine(5 * testElement);
            testElement.AddAttribute("href", "softuni.bg");
            testElement.AddAttribute("class", "links");
            testElement.AddContent("Click here");
            Console.WriteLine(testElement);

            Console.WriteLine();

            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 2);

            Console.WriteLine();

            ElementBuilder img = HTMLDispatcher.CreateImage("localhost/kartinka.png", "nicePic", "this is the picture");
            Console.WriteLine(img);
            ElementBuilder url = HTMLDispatcher.CreateURL("gosho.bg", "gosheto", "Go to link");
            Console.WriteLine(url);
            ElementBuilder input = HTMLDispatcher.CreateInput("text", "input", "empty");
            Console.WriteLine(input);
        }
    }
}

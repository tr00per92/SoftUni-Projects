using System;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystemTest
{
    public class Test
    {
        public static void Main()
        {
            Document doc = new Document("Testing document system", "Tr00peR");
            doc.Add(new Paragraph("I am a paragraph"));
            doc.Add(new Hyperlink("http://google.com"));
            doc.Add(new Paragraph("I am another paragraph"));
            doc.Add(new Heading("The best header"));

            Paragraph paragraph = new Paragraph();
            paragraph.Add(new TextElement("Default Font", Font.DefaultFont));
            paragraph.Add(new TextElement(" "));
            paragraph.Add(new TextElement("Second Red", new Font(color: Color.Red)));
            paragraph.Add(new TextElement(" "));
            paragraph.Add(new TextElement("Green Italic",
                new Font(color: Color.Green, style: FontStyle.Italic)));
            paragraph.Add(new Paragraph());
            paragraph.Add(new TextElement("Consolas Bold Blue Italic",
                    new Font(color: Color.Blue, style: FontStyle.BoldItalic, name: "Consolas")));
            doc.Add(paragraph);

            Console.WriteLine(doc);

            File.WriteAllText("../../output/document.html", doc.AsHTML);
            File.WriteAllText("../../output/document.txt", doc.AsText);
        }
    }
}

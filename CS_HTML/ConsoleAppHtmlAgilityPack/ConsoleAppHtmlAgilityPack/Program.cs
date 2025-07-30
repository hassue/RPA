using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHtmlAgilityPack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load HTML content
            var html = @"
            <html>
                <body>
                    <div id='main'>
                        <p class='info'>Hello World</p>
                        <a href='https://example.com'>Click Here</a>
                    </div>
                </body>
            </html>";

            // Load HTML into HtmlDocument
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            // Example 1: Extract text using XPath
            var paragraph = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='info']");
            Console.WriteLine("Paragraph text: " + paragraph.InnerText);

            // Example 2: Extract attribute using XPath
            var link = htmlDoc.DocumentNode.SelectSingleNode("//a");
            Console.WriteLine("Link href: " + link.GetAttributeValue("href", ""));
        }
    }
}

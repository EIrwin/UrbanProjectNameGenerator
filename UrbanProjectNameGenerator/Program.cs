using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace UrbanProjectNameGenerator
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter search term:");
            string term = Console.ReadLine();
            Console.WriteLine("Processing...");

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://www.urbandictionary.com/thesaurus.php?term=" + term);

            HtmlNodeCollection wordResults = document.DocumentNode.SelectNodes("//a[@class='word']");
            HtmlNodeCollection definitionResults = document.DocumentNode.SelectNodes("//div[@class='meaning']");
            HtmlNodeCollection exampleResults = document.DocumentNode.SelectNodes("//div[@class='example']");

            List<SearchResult> results = wordResults.Select((t, i) => new SearchResult()
                {
                    Word = t.InnerText, 
                    Definition = definitionResults[i].InnerText, 
                    Example = exampleResults[i].InnerText,
                }).ToList();


            results.ForEach(r =>
                {
                    Console.WriteLine(r.Word);
                    Console.WriteLine(r.Definition);
                    Console.WriteLine(r.Example);
                    Console.WriteLine();
                });
            

            Console.ReadLine();
        }
    }
}

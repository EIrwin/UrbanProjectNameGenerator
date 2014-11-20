using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace UrbanProjectNameGenerator.Service
{
    public class UrbanDictionaryThesaurusService:IUrbanDictionaryThesaurusService
    {
        public Task<SearchResult[]> Search(string term, bool allowQuestions, int? wordCount)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://www.urbandictionary.com/thesaurus.php?term=" + term);

            HtmlNodeCollection wordResults = document.DocumentNode.SelectNodes("//a[@class='word']");
            HtmlNodeCollection definitionResults = document.DocumentNode.SelectNodes("//div[@class='meaning']");
            HtmlNodeCollection exampleResults = document.DocumentNode.SelectNodes("//div[@class='example']");

            if (!wordResults.Any()) return Task.FromResult(new SearchResult[0]);

            List<SearchResult> results = wordResults.Select((t, i) => new SearchResult()
            {
                Word = t.InnerText,
                Definition = definitionResults[i].InnerText,
                Example = exampleResults[i].InnerText,
            }).ToList();

            return Task.FromResult(results.ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.ModelBinding;
using UrbanProjectNameGenerator.Models;
using UrbanProjectNameGenerator.Service;

namespace UrbanProjectNameGenerator.Modules
{
    public class SearchModule:NancyModule
    {
        public SearchModule(IUrbanDictionaryThesaurusService thesaurusService)
        {
            Get["/names",true] = async (contex, cancel) =>
                {
                    var model = this.Bind<SearchRequest>();

                    SearchResult[] results =
                        await thesaurusService.Search(model.Term, model.AllowQuestions, model.WordCount);

                    return Response.AsJson(new SearchResponse(){Results =results});
                };
        }
    }
}

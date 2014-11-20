using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanProjectNameGenerator.Service;

namespace UrbanProjectNameGenerator.Models
{
    public class SearchRequest
    {
        public string Term { get; set; }

        public bool AllowQuestions { get; set; }

        public int? WordCount { get; set; }
    }

    public class SearchResponse
    {
        public SearchResult[] Results { get; set; }
    }
}

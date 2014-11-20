using System.DirectoryServices;
using System.Threading.Tasks;

namespace UrbanProjectNameGenerator.Service
{
    public interface IUrbanDictionaryThesaurusService
    {
        Task<SearchResult[]> Search(string term, bool allowQuestions, int? wordCount);
    }
}
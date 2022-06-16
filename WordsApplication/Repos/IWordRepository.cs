using System.Threading.Tasks;
using WordsApplication.Models;

namespace WordsApplication.Repos
{
    public interface IWordRepository
    {
        public Task<Word> GetWords();
        public Task<Word> SaveWords(Word wordList, string pageSize);
    }
}

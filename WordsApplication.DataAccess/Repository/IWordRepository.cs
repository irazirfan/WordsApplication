using System.Threading.Tasks;

namespace WordsApplication.DataAccess
{
    public interface IWordRepository
    {
        public Task<string[]> GetWords();
        public Task<Word> SaveWords(Word wordList, string pageSize);
    }
}

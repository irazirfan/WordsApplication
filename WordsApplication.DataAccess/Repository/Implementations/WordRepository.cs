using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace WordsApplication.DataAccess.Implementations
{
    public class WordRepository : IWordRepository
    {
        private readonly WordDBContext _wordDbContext;

        public WordRepository( WordDBContext wordDBContext)
        {
            _wordDbContext = wordDBContext;
        }
        public async Task<string[]> GetWords()
        {
            var words = await _wordDbContext.Word.ToListAsync();
            int count = words.Count;
            string[] result = new string[count];
            for (int i = 0; i < words.Count; i++)
            {
                result[i] = words[i].Words.Substring(0, words[i].Lines);
            }

            return result;
        }

        public async Task<Word> SaveWords(Word wordList, string pageSize)
        {
            Word word = new Word()
            {
                Lines = Convert.ToInt16(pageSize),
                Words = wordList.Words
            };
            await _wordDbContext.AddAsync(word);
            var res = await _wordDbContext.SaveChangesAsync();

            if(res==1)
                return word;
            return null;

        }
    }
}

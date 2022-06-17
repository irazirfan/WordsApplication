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
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < words.Count; i++)
            {
                count += words[i].Words.Length / words[i].Lines;
                if (words[i].Words.Length % words[i].Lines != 0)
                    count++;
            }
            string[] result = new string[count];
            for (int i = 0; i < words.Count; i++)
            {
                int length = words[i].Lines;
                for (int j = 0; j < (words[i].Words.Length / words[i].Lines); j++)
                {
                    result[j] = words[i].Words.Substring(startIndex, length);
                    startIndex += length;
                }
                int mod = words[i].Words.Length % words[i].Lines;
                if (mod != 0)
                {
                    result[(words[i].Words.Length/words[i].Lines)] = words[i].Words.Substring(startIndex, mod);
                }
                startIndex = 0;
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

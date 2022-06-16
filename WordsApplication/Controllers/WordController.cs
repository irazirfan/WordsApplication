using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WordsApplication.Models;
using WordsApplication.Repos;

namespace WordsApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        [Route("post")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Word wordList, [FromHeader] string pageSize)
        {
            var res = await _wordRepository.SaveWords(wordList, pageSize);

            if (res == null)
            {
                return Ok(new { success = false, data = "", pageSize = pageSize });
            }
            return Ok(new { success = true, data = res, pageSize = pageSize });
        }

        [HttpGet]
        public async Task<Word> Get()
        {
            var words = await _wordRepository.GetWords();
            return words;
        }
    }
}

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WordsApplication.DataAccess;

namespace WordsApplication.Controllers
{
    [ApiController]
    [Route("Word")]
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Word wordList, [FromHeader] string pageSize)
        {
            var res = await _wordRepository.SaveWords(wordList, pageSize);

            if (res == null)
            {
                return Ok(new { success = false });
            }
            return Created(new Uri(Request.GetEncodedUrl() + "/" + wordList.Id), wordList);
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var words = await _wordRepository.GetWords();
            return Ok(words);
        }
    }
}

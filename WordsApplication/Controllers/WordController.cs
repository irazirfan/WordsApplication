using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WordsApplication.Models;

namespace WordsApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : ControllerBase
    {
        private readonly ILogger<WordController> _logger;
        private readonly WordDBContext _wordDbContext;

        public WordController(ILogger<WordController> logger, WordDBContext wordDBContext)
        {
            _logger = logger;
            _wordDbContext = wordDBContext;
        }

        [Route("post")]
        [HttpPost]
        public IActionResult Post([FromBody] Word wordList, [FromHeader] string pageSize)
        {
            Word word = new Word()
            {
                Lines = Convert.ToInt16(pageSize),
                Words = wordList.Words
            };

            _wordDbContext.Add(word);
            _wordDbContext.SaveChanges();
            
            return Ok( new { success = true, data = wordList, pageSize = pageSize });
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(words);
        //}
    }
}

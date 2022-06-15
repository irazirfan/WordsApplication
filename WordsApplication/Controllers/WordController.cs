using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WordsApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : ControllerBase
    {
        private static readonly string[] wordList = new[]
        {
            "Basketball", "Cricket", "Football", "Hockey", "Tennis", "Volleyball", "Badminton"
        };

        private readonly ILogger<WordController> _logger;

        public WordController(ILogger<WordController> logger)
        {
            _logger = logger;
        }

        [Route("post")]
        [HttpPost]
        public IActionResult Post([FromQuery] string wordList, [FromHeader] string pageSize)
        {   
            return Ok( new { success = true, data = wordList, pageSize = pageSize });
        }

        [HttpGet]
        public string[] Get()
        {
            return wordList;
        }
    }
}

using System;
using System.Collections;
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

        [HttpGet]
        public string[] Get()
        {
            return wordList;
        }
    }
}

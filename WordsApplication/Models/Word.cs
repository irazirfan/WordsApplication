using Newtonsoft.Json;

namespace WordsApplication.Models
{
    public class Word
    {
        [JsonProperty]
        public int Id { get; set; }
        public int Lines { get; set; }
        public string Words { get; set; }
    }
}

using Newtonsoft.Json;

namespace MarcoToSquadConverter
{
    public class SquadAnswer
    {
        [JsonProperty("answer_start")]
        public int AnswerStart { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}

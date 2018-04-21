using Newtonsoft.Json;

namespace MarcoToSquadConverter
{
    public class SquadQuestionAndAnswers
    {
        [JsonProperty("answers")]
        public SquadAnswer[] Answers { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

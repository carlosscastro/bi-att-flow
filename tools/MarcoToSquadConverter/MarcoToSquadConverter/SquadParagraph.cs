using Newtonsoft.Json;

namespace MarcoToSquadConverter
{
    public class SquadParagraph
    {
        [JsonProperty("context")]
        public string Context { get; set; }
        [JsonProperty("qas")]
        public SquadQuestionAndAnswers[] QuestionAndAnswers { get; set; }
    }
}

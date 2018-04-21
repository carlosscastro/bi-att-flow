using Newtonsoft.Json;

namespace MarcoToSquadConverter
{
    public class MsMarcoPassageQuestionAndAnswer
    {
        [JsonProperty("passages")]
        public MsMarcoPassage[] Passages { get; set; }
        [JsonProperty("query_id")]
        public int QueryId { get; set; }
        [JsonProperty("answers")]
        public string[] Answers { get; set; }
        [JsonProperty("query_type")]
        public string QueryType { get; set; }
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}

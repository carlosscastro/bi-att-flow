using Newtonsoft.Json;

namespace MarcoToSquadConverter
{
    public class MsMarcoPassage
    {
        [JsonProperty("is_selected")]
        public int IsSelected { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("passage_text")]
        public string PassageText { get; set; }
    }
}

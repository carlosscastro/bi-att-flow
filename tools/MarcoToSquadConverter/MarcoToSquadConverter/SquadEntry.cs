using Newtonsoft.Json;

namespace MarcoToSquadConverter
{
    public class SquadEntry
    {
        [JsonProperty("paragraphs")]
        public SquadParagraph[] Paragraphs { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

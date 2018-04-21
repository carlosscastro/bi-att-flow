using Newtonsoft.Json;

namespace MarcoToSquadConverter
{
    public class SquadDataset
    {
        [JsonProperty("data")]
        public SquadEntry[] Data { get; set; }
    }
}

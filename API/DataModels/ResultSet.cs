using Newtonsoft.Json;
namespace FootballApi.API.DataModels
{
    public class ResultSet
    {
        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("first")]
        public string? First { get; set; }

        [JsonProperty("last")]
        public string? Last { get; set; }

        [JsonProperty("played")]
        public int? Played { get; set; }
    }
}
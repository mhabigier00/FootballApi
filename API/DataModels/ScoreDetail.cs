using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class ScoreDetail
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }
    }
}

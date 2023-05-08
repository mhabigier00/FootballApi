using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Score
    {
        [JsonProperty("winner")]
        public string? Winner { get; set; }

        [JsonProperty("duration")]
        public string? Duration { get; set; }

        [JsonProperty("fullTime")]
        public ScoreDetail? FullTime { get; set; }

        [JsonProperty("halfTime")]
        public ScoreDetail? HalfTime { get; set; }
    }
}

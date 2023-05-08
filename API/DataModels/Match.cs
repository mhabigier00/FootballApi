using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Match
    {
        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("competition")]
        public Competition Competition { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("utcDate")]
        public string UtcDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("venue")]
        public string? Venue { get; set; }

        [JsonProperty("matchday")]
        public int Matchday { get; set; }

        [JsonProperty("stage")]
        public string? Stage { get; set; }

        [JsonProperty("group")]
        public object? Group { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty("homeTeam")]
        public HomeTeam HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public AwayTeam AwayTeam { get; set; }

        [JsonProperty("score")]
        public Score? Score { get; set; }

        [JsonProperty("odds")]
        public Odds? Odds { get; set; }

        [JsonProperty("referees")]
        public List<Referee> Referees { get; set; }
    }
}

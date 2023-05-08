using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class AwayTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("tla")]
        public string Tla { get; set; }

        [JsonProperty("crest")]
        public string Crest { get; set; }
    }
}

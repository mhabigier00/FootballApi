using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Referee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }
    }
}

using Newtonsoft.Json;
namespace FootballApi.API.DataModels
{
    public class Competition
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("emblem")]
        public string Emblem { get; set; }
    }
}
using Newtonsoft.Json;
namespace FootballApi.API.DataModels
{
    public class Filters
    {
        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("matchday")]
        public string Matchday { get; set; }
    }
}
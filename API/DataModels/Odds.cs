using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Odds
    {
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}

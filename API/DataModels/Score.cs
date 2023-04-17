using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Score
    {
        [JsonConstructor] public Score(string home, string away) 
        {
            Home = home;
            Away = away;
        }
        [JsonProperty("home")] public string Home { get; }
        [JsonProperty("away")] public string Away { get; }
    }
}

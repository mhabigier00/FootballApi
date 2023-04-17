using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class League
    {
        [JsonProperty("id")] public string Id { get;}
        [JsonProperty("name")] public string Name { get;}
        [JsonProperty("country")] public string Country { get;}
        [JsonProperty("logo")] public string Logo { get;}
        [JsonProperty("season")] public int Season { get;}
        [JsonProperty("round")] public string Round { get; }

        [JsonConstructor] public League(string id, string name, string country, string logo, int season, string round)
        {
            Id = id;
            Name = name;
            Country = country;
            Logo = logo;
            Season = season;
            Round = round;
        }
    }
}

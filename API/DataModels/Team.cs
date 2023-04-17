using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Team
    {
        [JsonProperty("id")] public string Id { get;}
        [JsonProperty("name")] public string Name { get;}
        [JsonProperty("logo")] public string Logo { get;}
        [JsonProperty("winner")] public bool IsWinner { get;}
        [JsonConstructor] public Team(string id, string name, string logo, bool isWinner) 
        {
            Id = id;
            Name = name;
            Logo = logo;
            IsWinner = isWinner;
        }
    
    }
}

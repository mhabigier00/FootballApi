using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Venue
    {
        [JsonProperty("id")] public string Id { get;}
        [JsonProperty("name")] public string Name { get;}
        [JsonProperty("city")] public string City { get; }

        [JsonConstructor] public Venue(string id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }
    }
}

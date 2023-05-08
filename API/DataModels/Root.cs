using Newtonsoft.Json;
namespace FootballApi.API.DataModels;
public class Root
{
    [JsonProperty("filters")]
    public Filters Filters { get; set; }

    [JsonProperty("resultSet")]
    public ResultSet ResultSet { get; set; }

    [JsonProperty("competition")]
    public Competition Competition { get; set; }

    [JsonProperty("matches")]
    public List<Match> Matches { get; set; }
}


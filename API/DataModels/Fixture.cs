using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Fixture
    {
        [JsonProperty("id")] public int Id { get;}
        [JsonProperty("referee")] public string Referee { get;}
        [JsonProperty("timezone")] public string Timezone { get; }
        [JsonProperty("date")] public string Date { get; }
        [JsonProperty("timestamp")] public int Timestamp { get; }

        [JsonConstructor] public Fixture(int id, string referee, string timezone, string date, int timestamp)
        {
            Id = id;
            Referee = referee;
            Timezone = timezone;
            Date = date;
            Timestamp = timestamp;
        }
    }
}

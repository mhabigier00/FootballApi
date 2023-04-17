using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Status
    {
        [JsonProperty("long")] public string Long { get; }
        [JsonProperty("short")] public string Short { get; }
        [JsonProperty("elapsed")] public int Elapsed { get; }

        [JsonConstructor] public Status(string _long, string _short, int elapsed) 
        {
            Long = _long;
            Short = _short;
            Elapsed = elapsed;
        }
    }
}

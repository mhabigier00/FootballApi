using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Season
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("currentMatchday")]
        public int? CurrentMatchday { get; set; }

        [JsonProperty("winner")]
        public object Winner { get; set; }
    }
}

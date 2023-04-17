using Newtonsoft.Json;

namespace FootballApi.API.DataModels
{
    public class Fixtures
    {
        [JsonProperty("fixture")] public Fixture Fixture { get;}
        [JsonProperty("league")] public League League { get;}
        [JsonProperty("score")] public Score Score { get;}
        [JsonProperty("status")] public Status Status { get;}
        [JsonProperty("team")] public Team Team { get;}
        [JsonProperty("venue")] public Venue Venue { get;}

        [JsonConstructor] public Fixtures(Fixture fixture, League league, Score score, Status status, Team team, Venue venue)
        {
            Fixture = fixture;
            League = league;
            Score = score;
            Status = status;
            Team = team;
            Venue = venue;
        }
    }
}

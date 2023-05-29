
namespace FootballApi.DataBase.Models
{
    public class FavouriteMatch
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int MatchId { get; set; }
        public string? MatchDescription { get; set; }

    }
}

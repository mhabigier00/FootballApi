using FootballApi.Data;
using FootballApi.DataBase.Models;

namespace FootballApi.DataBase
{
    public class FavouriteMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public FavouriteMatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFavoriteMatch(Guid userId, int matchId)
        {
            var favoriteMatch = new FavouriteMatch
            {
                UserId = userId,
                MatchId = matchId
            };

            _context.FavouriteMatches.Add(favoriteMatch);
            _context.SaveChanges();
        }

        public List<int> GetMatchIdsByUserId(Guid userId)
        {
            return _context.FavouriteMatches
                .Where(fm => fm.UserId == userId)
                .Select(fm => fm.MatchId)
                .ToList();
        }
    }

}

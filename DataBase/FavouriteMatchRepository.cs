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
        public void RemoveFavoriteMatch(Guid userId, int matchId)
        {
            var match = _context.FavouriteMatches.FirstOrDefault(c=> c.UserId == userId && c.MatchId == matchId);
            if(match != null)
            {
                _context.FavouriteMatches.Remove(match);
                _context.SaveChanges();
            }
        }
    }

}

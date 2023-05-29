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
        public void AddDescriptionToMatch(Guid userId, int matchId, string description)
        {
            var favouriteMatch = _context.FavouriteMatches.FirstOrDefault(fm => fm.UserId == userId && fm.MatchId == matchId);
            if (favouriteMatch != null)
            {
                favouriteMatch.MatchDescription = description;
                _context.SaveChanges();
            }
        }

        public string? GetDescription(Guid userId, int matchId)
        {
            var favouriteMatch = _context.FavouriteMatches.FirstOrDefault(m => m.UserId == userId && m.MatchId == matchId);
            return favouriteMatch?.MatchDescription ?? null;
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

using FootballApi.API;
using FootballApi.API.DataModels;
using FootballApi.Models;
using FootballApi.DataBase;
using FootballApi.DataBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace FootballApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly FavouriteMatchRepository _favouriteMatchRepository;
        public HomeController(ILogger<HomeController> logger, IMemoryCache cache, UserManager<IdentityUser> userManager, FavouriteMatchRepository favouriteMatchRepository)
        {
            _logger = logger;
            _cache = cache;
            _userManager = userManager;
            _favouriteMatchRepository = favouriteMatchRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Laliga(int matchday = 1)
        {
            var cacheKey = $"Laliga{matchday}";
            if (_cache.TryGetValue(cacheKey, out Root data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string> { { "matchday", $"{matchday}" } }, "/competitions/PD/matches");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<Root>(jsonString);
            _cache.Set(cacheKey, page, TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task<IActionResult> Serie_A(int matchday = 1)
        {
            var cacheKey = $"Serie_A{matchday}";
            if (_cache.TryGetValue(cacheKey, out Root data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string> { { "matchday", $"{matchday}" } }, "/competitions/SA/matches");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<Root>(jsonString);
            _cache.Set(cacheKey, page, TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task<IActionResult> Bundesliga(int matchday=1)
        {
            var cacheKey = $"Bundesliga{matchday}";
            if (_cache.TryGetValue(cacheKey, out Root data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string> { { "matchday", $"{matchday}" } }, "/competitions/BL1/matches");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<Root>(jsonString);
            _cache.Set(cacheKey, page, TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task<IActionResult> Premier_League(int matchday=1)
        {
            var cacheKey = $"Premier_League{matchday}";
            if(_cache.TryGetValue(cacheKey, out Root data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string> { { "matchday", $"{matchday}" } }, "/competitions/PL/matches");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<Root>(jsonString);
            _cache.Set(cacheKey, page,TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task<IActionResult> Ligue_1(int matchday = 1)
        {
            var cacheKey = $"Ligue_1{matchday}";
            if (_cache.TryGetValue(cacheKey, out Root data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string> { { "matchday", $"{matchday}" } }, "/competitions/FL1/matches");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<Root>(jsonString);
            _cache.Set(cacheKey, page, TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task<IActionResult> Sample(int matchday = 1)
        {
            var cacheKey = $"Sample{matchday}";
            if (_cache.TryGetValue(cacheKey, out Root data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string> { { "matchday", $"{matchday}" } }, "/competitions/PL/matches");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<Root>(jsonString);
            _cache.Set(cacheKey, page, TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task<IActionResult> Match(int id=0)
        {
            var cacheKey = $"Match{id}";
            if (_cache.TryGetValue(cacheKey, out Match data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string>(),$"/matches/{id}");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<Match>(jsonString);
            _cache.Set(cacheKey, page, TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task<IActionResult> FavouriteMatch(int id = 0)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cacheKey = $"Match{id}";
            if (_cache.TryGetValue(cacheKey, out DBMatch data))
            {
                return View(data);
            }
            var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
            var response = await client.GetData(new Dictionary<string, string>(), $"/matches/{id}");
            var jsonString = await response.Response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<DBMatch>(jsonString);
            var description = _favouriteMatchRepository.GetDescription(Guid.Parse(userId), page.Id);
            page.Description = description;
            _cache.Set(cacheKey, page, TimeSpan.FromMinutes(5));
            return View(page);
        }
        public async Task AddMatch(int matchId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cacheKey = $"Favourites{userId}";
            if (User.Identity.IsAuthenticated)
            {
                if (Guid.TryParse(userId, out Guid parsedUserId))
                {
                    _favouriteMatchRepository.AddFavoriteMatch(parsedUserId, matchId);
                    _cache.Remove(cacheKey);
                }
                else
                {
                    throw new InvalidCastException("Invalid Data");
                }
            }
            else
            {
                throw new InvalidDataException("Invalid User");
            }
    
        }
        public async Task AddDescription(int matchId, string description)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cacheKey = $"Description{userId},{matchId}";
            if (User.Identity.IsAuthenticated)
            {
                if (Guid.TryParse(userId, out Guid parsedUserId))
                {
                    _favouriteMatchRepository.AddDescriptionToMatch(parsedUserId, matchId, description);
                    _cache.Remove(cacheKey);
                }
                else
                {
                    throw new InvalidCastException("Invalid Data");
                }
            }
            else
            {
                throw new InvalidDataException("Invalid User");
            }
        }

        public async Task DeleteMatch(int matchId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cacheKey = $"Favourites{userId},{matchId}";
            if (User.Identity.IsAuthenticated)
            {
                if(Guid.TryParse(userId,out Guid parsedUserId))
                {
                    _favouriteMatchRepository.RemoveFavoriteMatch(parsedUserId, matchId);
                    _cache.Remove(cacheKey);
                }
                else
                {
                    throw new Exception();
                }
            }
            else { throw new InvalidDataException(); }
        }
        public async Task<IActionResult> Favourites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cacheKey = $"Favourites{userId}";
            if (User.Identity.IsAuthenticated)
            {
                if (Guid.TryParse(userId, out Guid parsedUserId))
                {
                    var matches = _favouriteMatchRepository.GetMatchIdsByUserId(parsedUserId);
                    if(matches.Count == 0)
                    {
                        var empty = new Root
                        {
                            Matches = new List<Match>()
                        };
                        _cache.Set(cacheKey, empty);
                        return View(empty);
                    }
                    var matchString = string.Join(",", matches);
                    var client = new Client("https://api.football-data.org/v4", "9059e4cb93de4662bffe09f3f205ea64");
                    var response = await client.GetData(new Dictionary<string, string> { { "ids", $"{matchString}" } }, "/matches");
                    var jsonString = await response.Response.Content.ReadAsStringAsync();
                    var page = JsonConvert.DeserializeObject<Root>(jsonString);
                    _cache.Set(cacheKey, page);
                    return View(page);
                }
                else
                {
                    throw new InvalidCastException("Invalid Data");
                }
            }
            else
            {
                throw new InvalidDataException("Invalid User");
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
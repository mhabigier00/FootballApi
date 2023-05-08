﻿using FootballApi.API;
using FootballApi.API.DataModels;
using FootballApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FootballApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
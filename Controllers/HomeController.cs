using FootballApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FootballApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Laliga()
        {
            return View();
        }
        public IActionResult Serie_A()
        {
            return View();
        }
        public IActionResult Bundesliga()
        {
            return View();
        }
        public IActionResult Premier_League()
        {
            return View();
        }
        public IActionResult Ligue_1()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
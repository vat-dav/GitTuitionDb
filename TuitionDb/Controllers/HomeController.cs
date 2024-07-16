using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TuitionDb.Models;
using TuitionDb.Areas.Identity.Data;

namespace TuitionDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // returns the index view if asp-action is "Index" and selected
        {
            return View();
        }

        public IActionResult HowToOperate() // returns the HowToOperate view if asp-action is "HowToOperate" and selected
        {
            return View();
        }
        public IActionResult Privacy() // returns the Privacy view if asp-action is "Privacy" and selected
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

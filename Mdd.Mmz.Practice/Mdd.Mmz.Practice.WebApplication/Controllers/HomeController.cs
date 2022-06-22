using Mdd.Mmz.Practice.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Mdd.Mmz.Practice.Core;
using Mdd.Mmz.Practice.Infrastructure;

namespace Mdd.Mmz.Practice.WebApplication.Controllers
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
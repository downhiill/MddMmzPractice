﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Mdd.Mmz.Practice.WebApplication.Models;
using Mdd.Mmz.Practice.Core;
using Mdd.Mmz.Practice.Infrastructure;

namespace Mdd.Mmz.Practice.WebApplication.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly ILogger<PharmacyController> _logger;

        //private readonly IModel model = new Model(new RepositoryFile());
        private readonly IModel model = new Model(new RepositoryDb());


        public PharmacyController(ILogger<PharmacyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index2()
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

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Mdd.Mmz.Practice.WebApplication.Models;
using Mdd.Mmz.Practice.Core;
using Mdd.Mmz.Practice.Infrastructure;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Mdd.Mmz.Practice.WebApplication.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;

        //private readonly IModel model = new Model(new RepositoryFile());
        private readonly IModel model = new Model(new RepositoryDb());


        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index1()
        {
            return View();

        }
        [Authorize(Roles = "Admin,User")]
        public JsonResult Get()
        {
            try
            {
                var people = model.Get();

                return Json(people);

            }
            catch (Exception e)
            {
                return Json(new { error1 = true, message = e.Message });
            }
            
        }
        [Authorize(Roles = "Admin")]
        public JsonResult GetById(int personId)
        {
            try
            {
                var person = model.Get(personId);

                return Json(person);

            }
            catch (Exception e)
            {
                return Json(new { error1 = true, message = e.Message });
            }      

        }
        [Authorize(Roles = "Admin")]
        public JsonResult Save(Person person)
        {
            try
            {
                model.Save(person);

                return Json(person);

            }
            catch (Exception e)
            {
                return Json(new { error1 = true, message = e.Message });
            }

        }
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(Person person)
        {
            try
            {
                model.Delete(person);

                return Json(true);

            }
            catch (Exception e)
            {
                return Json(new { error1 = true, message = e.Message });
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Mdd.Mmz.Practice.WebApplication.Models;
using Mdd.Mmz.Practice.Core;
using Mdd.Mmz.Practice.Infrastructure;

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

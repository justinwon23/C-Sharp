using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ViewResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [Route("method")]
        public IActionResult Method(Survey newSurvey)
        {
            if (ModelState.IsValid)
            {
                // HttpContext.Session.SetString("Name", newSurvey.Name);
                return RedirectToAction("Results", newSurvey);
            }
            else
            {
                return View("Index");
            }
            
        }

        [HttpGet("resultsss")]
        public ViewResult Results(Survey newSurvey)
        {
            return View("Results", newSurvey);
        }




    }
}

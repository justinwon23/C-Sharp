using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public ViewResult Index()
        {
            DateTime dateTime = DateTime.Now;
            

            ViewBag.dateOnly = DateTime.Now.ToString("MMMM dd, yyyy");
            ViewBag.timeOnly = DateTime.Now.ToString("h:mm tt");


            return View();
        }
    }
}
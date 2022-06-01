using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("method")]
        public IActionResult Method(User user)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("NewUser");
            }

            else
            {
                return View("Index");
            }
        }

        [HttpGet("hahaha")]
        public ViewResult NewUser()
        {
            return View();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ChefsDishesContext db;
        public HomeController(ChefsDishesContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Chefs = db.Chefs
            .Include(C => C.SubmittedDishes);
            return View();
        }

        [HttpGet("AddChef")]
        public IActionResult AddChef()
        {
            return View("AddChef");
        }

        [HttpPost("Create")]

        public IActionResult Create(Chef newChef)
        {
            if (ModelState.IsValid == false)
            {
                return View("AddChef");
            }

            db.Chefs.Add(newChef);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
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

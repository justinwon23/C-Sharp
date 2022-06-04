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
    public class DishController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ChefsDishesContext db;
        public DishController(ChefsDishesContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }


        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.Dishes = db.Dishes
            .Include(D => D.Writer);
            return View("Dishes");
        }

        [HttpGet("adddish")]
        public IActionResult AddDish()
        {
            ViewBag.Chefs = db.Chefs.ToList();
            return View("AddDish");
        }

        [HttpPost("Create/Dish")]

        public IActionResult Create(Dish newDish)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Chefs = db.Chefs.ToList();
                return View("AddDish");
            }

            db.Dishes.Add(newDish);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
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

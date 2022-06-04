using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crudelicious.Models;

namespace Crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CrudeliciousContext db;

        public HomeController(CrudeliciousContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> DishList = db.Dishes.OrderByDescending(D => D.CreatedAt).ToList();
            // DishList.OrderBy(D => D.CreatedAt);
            // DishList.OrderByDescending(D => D.CreatedAt);

            return View("Index", DishList);
        }


        [HttpGet("New")]
        public IActionResult New()
        {

            return View();
        }


        [HttpPost("Create")]

        public IActionResult Create(Dish newDish)
        {
            if (ModelState.IsValid == false)
            {
                return View("New");
            }

            db.Dishes.Add(newDish);

            db.SaveChanges();

            

            return RedirectToAction("Index");
        }

        [HttpGet("showOne/{dishId}")]
        public IActionResult ShowOne(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(d => d.CrudeliciousID == dishId);

            if (dish == null)
            {
                return RedirectToAction("Index");
            }
            
            return View("ShowOne", dish);
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(d => d.CrudeliciousID == dishId);

            if (dish == null)
            {
                return RedirectToAction("Index");
            }

            return View("Edit", dish);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult Update(int dishId, Dish editDish)
        {
            if (ModelState.IsValid == false)
            {
                editDish.CrudeliciousID = dishId;
                return View("Edit", editDish);
            }

            Dish dish = db.Dishes.FirstOrDefault(d => d.CrudeliciousID == dishId);
            
            if (dish == null)
            {
                return RedirectToAction("Index");
            }

            dish.DishName = editDish.DishName;
            dish.ChefsName = editDish.ChefsName;
            dish.Calories = editDish.Calories;
            dish.Description = editDish.Description;
            dish.Tastiness = editDish.Tastiness;
            dish.UpdatedAt = DateTime.Now;

            db.Dishes.Update(dish);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost("delete/{dishId}")]
        public IActionResult Delete (int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(d => d.CrudeliciousID == dishId);
            
            if (dish != null)
            {
                db.Dishes.Remove(dish);
                db.SaveChanges();
            }

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

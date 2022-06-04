using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ProductsCategoriesContext db;
        public CategoryController(ProductsCategoriesContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }

        [HttpGet("category")]
        public IActionResult Index()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View("Index");
        }

        [HttpPost("category/create")]
        // PASS LIST OF CATEGORIES FROM INDEX TO HERE
        public IActionResult Create(Category newCategory)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Categories = db.Categories.ToList();
                return View("Index");
            }
            db.Categories.Add(newCategory);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet("category/{categoryId}")]
        public IActionResult ShowOne(int categoryId)
        {
            ViewBag.Products = db.Products.ToList();
            
            ViewBag.Categories = db.Categories
            .Include(c => c.Belongings)
            .ThenInclude(b => b.Product)
            .FirstOrDefault(c => c.Categoryid == categoryId);

            return View("ShowOne");
            
        }

        [HttpPost("adds/{categoryId}")]
        public IActionResult CreateAssoc(int categoryId, Classified newClassified)
        {
            if (ModelState.IsValid == false)
            {
            ViewBag.Products = db.Products.ToList();
            
            ViewBag.Categories = db.Categories
            .Include(c => c.Belongings)
            .ThenInclude(b => b.Product)
            .FirstOrDefault(c => c.Categoryid == categoryId);                
                
                return View("ShowOne");
            }
            newClassified.Categoryid = (int) categoryId;
            db.Classifications.Add(newClassified);
            db.SaveChanges();

            return RedirectToAction("ShowOne");
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

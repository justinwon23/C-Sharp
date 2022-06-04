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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ProductsCategoriesContext db;
        public HomeController(ProductsCategoriesContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Products = db.Products.ToList();
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost("create")]
        // MAKE SURE TO PASS LIST OF PRODUCTS BACK INTO INDEX
        public IActionResult Create(Product newProduct)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Products = db.Products.ToList();
                return View("Index");
            }

            db.Products.Add(newProduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("products/{productId}")]
        public IActionResult ShowOne(int productId)
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Products = db.Products
            .Include(p => p.Classified)
            .ThenInclude(c => c.Category)
            .FirstOrDefault(p => p.Productid == productId);
            

            return View("ShowOne");
            
        }

        [HttpPost("add/{productId}")]
        public IActionResult CreateAssoc(int productId, Classified newClassified)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Products = db.Products
                .Include(p => p.Classified)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(p => p.Productid == productId);
                
                return View("ShowOne");
            }

            newClassified.Productid = (int) productId;
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

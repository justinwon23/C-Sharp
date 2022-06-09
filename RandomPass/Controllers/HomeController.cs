using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPass.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            static string GeneratePasscode()
            {
                string[] RandomCharacters = new string[]
                {
                    "A","B", "C", "D", "E", "F", "G", "H","I", "J", "K", "L",
                    "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z",
                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
                };


                Random rand = new Random();
                string passcode = "";
                for (int i = 0; i <= 13; i++)
                {

                    int RandomIndex = rand.Next(0, 35);

                    passcode += RandomCharacters[RandomIndex];
                }
                return passcode;
            }

            string NewPasscode = GeneratePasscode();
            HttpContext.Session.SetString("passcode", NewPasscode);

            
            
            // if (CounterCounting < 2)
            // {
            // HttpContext.Session.SetInt32("Counter", 2);
                
            // }

            int? CounterCounting = HttpContext.Session.GetInt32("Counter");
            if (CounterCounting == null)
            {
            HttpContext.Session.SetInt32("Counter", 1);
            }
            




            return View();
        }

        [HttpPost("")]

        public IActionResult Method()
        {


            static string GeneratePasscode()
            {
                string[] RandomCharacters = new string[]
                {
                    "A","B", "C", "D", "E", "F", "G", "H","I", "J", "K", "L",
                    "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z",
                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
                };

                Random rand = new Random();
                string passcode = "";
                for (int i = 0; i <= 13; i++)
                {

                    int RandomIndex = rand.Next(0, 35);

                    passcode += RandomCharacters[RandomIndex];
                }
                return passcode;
            }

            
            string NewPasscode = GeneratePasscode();
            HttpContext.Session.SetString("passcode", NewPasscode);
            
            int? CounterCounting = HttpContext.Session.GetInt32("Counter");
            CounterCounting++;
            
            // int NewCounting = Convert.ToInt32(CounterCounting);
            // HttpContext.Session.SetInt32("Counter", NewCounting);
            
            HttpContext.Session.SetInt32("Counter", (int)CounterCounting);

            // return View("Index");
            
            
            return RedirectToAction("Index");
            // return RedirectToAction("NewRender");
        }

        [HttpGet("Generated")]

        public ViewResult NewRender()
        {
            return View("Index");
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

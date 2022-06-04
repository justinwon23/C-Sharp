using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        private readonly ILogger<HomeController> _logger;

        private LoginRegContext db;
        public HomeController(LoginRegContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(User newUser)
        {
            
            if (ModelState.IsValid)
            {
                bool isEmailTaken = db.Users.Any(u => u.Email == newUser.Email);
                if (isEmailTaken)
                {
                    ModelState.AddModelError("Email", "is taken");
                }
            }

            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("login")]

        public IActionResult Logging(LoginUser loginuser)
        {
            if (ModelState.IsValid == false)
            {
                return View("Login");
            }

            User dbUser = db.Users.FirstOrDefault(u => u.Email == loginuser.LoginEmail);

            if (dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", "not found.");
                return View("Login");
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(loginuser, dbUser.Password, loginuser.LoginPassword);

            if (pwCompareResult == 0)
            {
                ModelState.AddModelError("LoginPassword", "invalid");
            }

            HttpContext.Session.SetInt32("UserId", dbUser.Userid);
            return RedirectToAction("Success");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            if (uid == null)
            {
                return RedirectToAction("Login");
            }
            return View("Success");
        }

        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();


            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
            .Where(W => W.Name.Contains("Women"))
            .ToList();

            ViewBag.HockeyLeauges = _context.Leagues
            .Where(H => H.Sport.Contains("Hockey"))
            .ToList();

            ViewBag.NoFootball = _context.Leagues
            .Where(NF => !NF.Sport.Contains("Football"))
            .ToList();

            ViewBag.Conferences = _context.Leagues
            .Where(C => C.Name.Contains("onference"))
            .ToList();
            
            ViewBag.Atlantic = _context.Leagues
            .Where(C => C.Name.Contains("Atlantic"))
            .ToList();
            
            ViewBag.Dallas = _context.Teams
            .Where(C => C.Location.Contains("Dallas"))
            .ToList();

            ViewBag.Raptors = _context.Teams
            .Where(C => C.TeamName.Contains("Raptors"))
            .ToList();

            ViewBag.City = _context.Teams
            .Where(C => C.Location.Contains("City"))
            .ToList();

            ViewBag.T = _context.Teams
            .Where(C => C.TeamName.StartsWith("T"))
            .ToList();

            ViewBag.Alpha = _context.Teams
            .OrderBy(t => t.Location);

            ViewBag.ReverseAlpha = _context.Teams
            .OrderByDescending(t => t.TeamName);

            ViewBag.Cooper = _context.Players
            .Where(L => L.LastName == "Cooper");

            ViewBag.Joshua = _context.Players
            .Where(F => F.FirstName == "Joshua");

            ViewBag.CooperNoJosh = _context.Players
            .Where(L => L.LastName == "Cooper" && L.FirstName != "Joshua");

            ViewBag.AlexanderWyatt = _context.Players
            .Where(F => F.FirstName == "Alexander" || F.FirstName == "Wyatt");
            
            

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}
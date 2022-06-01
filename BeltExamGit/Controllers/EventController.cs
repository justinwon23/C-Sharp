using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers
{
    public class EventController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
                
            }
        }
        private readonly ILogger<HomeController> _logger;

        private BeltExamContext db;
        public EventController(BeltExamContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }
        public IActionResult Dashboard()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            
            ViewBag.AllEvents = db.Events
            .Include(e => e.Planner)
            .Include(e => e.EventUserJoins)
            .ThenInclude(euj => euj.User)
            .OrderBy(euj => euj.EventDate)
            .ToList();
            
            return View("Dashboard");
        }

        [HttpGet("createevent")]
        public IActionResult CreateEvent()
        {
            return View("CreateEvent");
        }

        [HttpGet("showOne/{eventId}")]
        public IActionResult ShowOne(int eventId)
        {
            Event OneEvent = db.Events
            .Include(e => e.Planner)
            .Include(e => e.EventUserJoins)
            .ThenInclude(euj => euj.User)
            .FirstOrDefault(e => e.EventId == eventId);

            return View("ShowOne", OneEvent);
        }

        [HttpPost("delete/{eventId}")]
        public IActionResult Delete(int eventId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Event OneEvent = db.Events.FirstOrDefault(w => w.EventId == eventId);

            if (OneEvent == null || OneEvent.UserId != uid)
            {
                return RedirectToAction("Dashboard");
            }

            db.Events.Remove(OneEvent);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        [HttpPost("EventJoin/{eventId}")]
        public IActionResult UserEventJoin(int eventId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            EventUserJoin existingJoin = db.EventUserJoins
            .FirstOrDefault(j => j.EventId == eventId && j.UserId == uid);

            if (existingJoin == null)
            {
                EventUserJoin newJoin = new EventUserJoin()
                {
                    UserId = (int)uid,
                    EventId = eventId
                };

                db.EventUserJoins.Add(newJoin);
            }
            else
            {
                db.Remove(existingJoin);
            }
            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        
        [HttpPost("newevent/{userId}")]
        public IActionResult NewEvent(int userId, Event newEvent)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            newEvent.UserId = userId;
            
            if (ModelState.IsValid == false)
            {
                return View("CreateEvent");
            }

            db.Events.Add(newEvent);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
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

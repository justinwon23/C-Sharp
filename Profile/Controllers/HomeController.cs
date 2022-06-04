using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Profile
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public string Index()
        {
            return "This is my index";
        }
        
        [Route("projects")]
        [HttpGet]
        public string Projects()
        {
            return "These are my projects";
        }
        
        [HttpGet("contact")]
        // [HttpGet]
        public string Contact()
        {
            return "This is my contact";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoApp.Models;
using System.IO;
using Newtonsoft.Json;
using DempApp.Data;
using DemoApp.Domain;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DeveloperContext _developerContext;
        private List<Developer> developerList;
        public HomeController(ILogger<HomeController> logger, DeveloperContext developerContext)
        {
            _logger = logger;
            _developerContext = developerContext;
        }

        public IActionResult Index()
        {
            developerList = _developerContext.Developer.ToList();
            return View(developerList);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public JsonResult SaveDevelopers([FromBody]List<Developer> developers)
        {
            
            if (developers.Count > 0)
            {
                foreach (var item in developers)
                {
                    _developerContext.Developer.Add(item);
                    _developerContext.SaveChanges();
                }
                developerList = _developerContext.Developer.ToList();
            }
            return Json(developerList);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

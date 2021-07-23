using DROPDOWNLIST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace DROPDOWNLIST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Dropdown(string drop)
        {
            List<string> state = new List<string>();

            //db call for getting the district using state

            switch (drop.ToLower())
            {
                case "india":
                    state.Add("TamilNadu");
                    state.Add("AndhraPradesh");
                    break;

                case "us":
                    state.Add("NewYork");
                    state.Add("Washington");
                    break;

                case "uk":
                    state.Add("Scotland");
                    state.Add("England");
                    break;

                case "canada":
                    state.Add("Toronto");
                    state.Add("BritishColombia");
                    break;
            }



            //return districts;
            return Json(new { msg = "success", drop = state });
        }

        public JsonResult District(string state)
        {
            List<string> District = new List<string>();
            switch (state.ToLower())
            {
                case "tamilnadu":
                    District.Add("Chennai");
                    break;

                case "andhrapradesh":
                    District.Add("Nellore");
                    break;

                case "newyork":
                    District.Add("Brooklyn");
                    break;

                case "washington":
                    District.Add("Olympia");
                    break;

                case "scotland":
                    District.Add("GlasGow");
                    break;

                case "england":
                    District.Add("London");
                    break;

                case "toronto":
                    District.Add("Brampton");
                    break;

                case "britishcolombia":
                    District.Add("Victoria");
                    break;
            }

            return Json(new { msg = "success", State = District });
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

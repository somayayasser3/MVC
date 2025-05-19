using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab01.Controllers
{
    public class HomeController : Controller
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //public IActionResult GetResultById(int Id, string Name)
        //{
        //    switch (Id)
        //    {
        //        case int res when (Id % 3 == 0):
        //            return Content($"Your Id = {Id}, Your Name = {Name}");
        //        case int res when (Id % 3 == 1):
        //            {
        //                return View("AnotherView");
        //            }
        //        default:
        //            return NotFound();
        //    }
        //}

        public IActionResult content(int id, string Name) 
        { 
            return new ContentResult { Content = $"Id = {id}, Name = {Name}" };
        }

        public IActionResult view(string Name)
        {
            return new ViewResult { ViewName = Name };
        }

        public IActionResult GetResultById(int Id, string Name)
        {
            switch (Id)
            {
                case int res when (Id % 3 == 0):
                    {
                        return content(Id, Name);
                    };
                case int res when (Id % 3 == 1):
                    {

                        return view("AnotherView");
                    }
                default:
                    return NotFound();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wba.EfBasics.Web.Models;

namespace Wba.EfBasics.Web.Controllers
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
            //create a cookie
            //check if cookie exists
            if(!HttpContext.Request.Cookies.ContainsKey("MyCookie"))
            {
                var cookieOptions
                = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(3)
                };
                HttpContext.Response.Cookies.Append("Username", "gehashte", cookieOptions);
            }
            //create a sessio
            HttpContext.Session.SetInt32("LoggedIn", 1);
            return View();
        }

        public IActionResult Privacy()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            var myCookie = HttpContext.Request.Cookies["MyCookie"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

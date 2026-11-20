using Microsoft.AspNetCore.Mvc;
using PL.Web.Models;
using System.Diagnostics;

namespace PL.Web.Controllers
{
    public class HomeController : Controller
    {
        // / veya /home/index/
        public IActionResult Index()
        {
            return View();
        }

        // /home/about/
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
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

        // /home/hello
        public string Hello()
        {
            return "Hello world!";
        }
    }
}

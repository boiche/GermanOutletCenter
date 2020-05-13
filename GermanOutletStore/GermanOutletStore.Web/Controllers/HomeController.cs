using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GermanOutletStore.Web.Models;
using GermanOutletStore.Data;
using AutoMapper;

namespace GermanOutletStore.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(StoreDbContext context, IMapper mapper) : base (context, mapper) { }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}

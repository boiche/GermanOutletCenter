using AutoMapper;
using GermanOutletStore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GermanOutletStore.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public HomeController(StoreDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }        
    }
}
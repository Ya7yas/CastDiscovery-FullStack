using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScenePro.Data;
using ScenePro.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace ScenePro.Controllers
{
    
    public class HomeController : Controller
    {


            private readonly AppDbContext _context;

            public HomeController(AppDbContext context)
            {
                _context = context;
            }

            public IActionResult Index()
            {
          return View(_context.Events.ToList());
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}


  

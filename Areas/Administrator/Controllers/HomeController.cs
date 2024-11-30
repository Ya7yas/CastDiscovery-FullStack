using Microsoft.AspNetCore.Mvc;

namespace ScenePro.Areas.Administor.Controllers
{
    public class HomeController : Controller
    {
        [Area("Administrator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

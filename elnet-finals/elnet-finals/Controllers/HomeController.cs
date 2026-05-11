using Microsoft.AspNetCore.Mvc;

namespace elnet_finals.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

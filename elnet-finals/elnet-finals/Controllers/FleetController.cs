using Microsoft.AspNetCore.Mvc;

namespace elnet_finals.Controllers
{
    public class FleetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

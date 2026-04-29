using Microsoft.AspNetCore.Mvc;

namespace elnet_finals.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

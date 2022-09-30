using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GajiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

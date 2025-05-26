using Microsoft.AspNetCore.Mvc;

namespace ShopTARge23.Controllers
{
    public class OpenWeathersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

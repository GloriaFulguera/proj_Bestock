using Microsoft.AspNetCore.Mvc;

namespace proj_Bestock.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

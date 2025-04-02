using Microsoft.AspNetCore.Mvc;

namespace proj_Bestock.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Index()
        {
            return View("AdmTienda");
        }
    }
}

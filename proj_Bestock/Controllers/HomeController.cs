using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Services;

namespace proj_Bestock.Controllers
{
    public class HomeController : Controller
    {
        private readonly MenuService _menuService;
        public HomeController(MenuService menuService)
        {
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            var rolId = HttpContext.Session.GetInt32("RolId");
            var items=_menuService.ObtenerMenu(rolId.Value);
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Services;
using System.Security.Cryptography;
using System.Text.Json;

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
            var menuJSON = JsonSerializer.Serialize(items);
            HttpContext.Session.SetString("MenuItems", menuJSON);

            return View(items);
        }
    }
}

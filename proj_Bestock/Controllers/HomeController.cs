using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Services;
using System.Security.Cryptography;
using System.Text.Json;

namespace proj_Bestock.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MenuService _menuService;
        public HomeController(MenuService menuService)
        {
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioLogueado") != "true")
            {
                // Si no hay sesión, redirigimos al login
                return RedirectToAction("Login", "Cuenta");
            }
            var rolId = HttpContext.Session.GetInt32("RolId");
            var items=_menuService.ObtenerMenu(rolId.Value);
            var menuJSON = JsonSerializer.Serialize(items);
            HttpContext.Session.SetString("MenuItems", menuJSON);

            return View(items);
        }
    }
}

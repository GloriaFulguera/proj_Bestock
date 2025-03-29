using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Models;

namespace proj_Bestock.Controllers
{
    public class CuentaController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(Usuario model)
        {
            
            // Redirigir al login después del registro
            return RedirectToAction("Login");
        }

    }
}

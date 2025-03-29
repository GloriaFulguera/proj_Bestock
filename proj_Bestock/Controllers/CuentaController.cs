using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using proj_Bestock.Data.Repositories;
using proj_Bestock.Models;
using System.Security.Claims;

namespace proj_Bestock.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UsuarioRepository _usuarioRepo;
        public CuentaController(UsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
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
            bool rta=_usuarioRepo.RegistrarUsuario(model);
            // Redirigir al login después del registro
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario model) // Ahora recibe Usuario directamente
        {
            Usuario rta=_usuarioRepo.AutenticarUsuario(model.Email,model.UserPass);
            return RedirectToAction("Login");
        }

    }
}

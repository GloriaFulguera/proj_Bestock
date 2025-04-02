using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using proj_Bestock.Models;
using System.Security.Claims;
using proj_Bestock.Services;
using Microsoft.AspNetCore.Http;

namespace proj_Bestock.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AutenticaService _usuarioRepo;
        public CuentaController(AutenticaService usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Registrar()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Registrar(Usuario model)
        //{
        //    bool rta = _usuarioRepo.RegistrarUsuario(model);
        //    // Redirigir al login después del registro
        //    if (rta)
        //        return RedirectToAction("Login");
        //    return View();
        //}
        [HttpPost]
        public IActionResult Login(Usuario model) // Ahora recibe Usuario directamente
        {
            ViewBag.ErrorMessage = null;
            Usuario rta = _usuarioRepo.AutenticarUsuario(model.Email, model.UserPass);
            if (rta != null)
            {
                HttpContext.Session.SetInt32("UserId", rta.Id);
                HttpContext.Session.SetInt32("RolId", rta.Rol);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Credenciales incorrectas";
            return View();
        }

    }
}

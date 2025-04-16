using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using proj_Bestock.Models;
using System.Security.Claims;
using proj_Bestock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;



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

        [HttpPost]
        public IActionResult Login(Usuario model) // Ahora recibe Usuario directamente
        {
            ViewBag.ErrorMessage = null;
            Usuario rta = _usuarioRepo.AutenticarUsuario(model.Email, model.UserPass);
            if (rta != null)
            {
                HttpContext.Session.SetInt32("RolId", rta.Rol);

                var claims = new List<Claim>{
                   new Claim(ClaimTypes.Name, rta.Nombre),
                    new Claim("UsuarioId", rta.Nombre.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, "MiCookieAuth");

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                };

                HttpContext.SignInAsync("MiCookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);
                HttpContext.Session.SetString("UsuarioLogueado", "true");


                //

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Credenciales incorrectas";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MiCookieAuth");
            HttpContext.Session.Clear(); // Por si usás sesión también
            return RedirectToAction("Login", "Cuenta");
        }
    }

    //[HttpPost]
    //public async Task<IActionResult> Logout()s
    //{
    //    await HttpContext.SignOutAsync("MiCookieAuth");
    //    return RedirectToAction("Login", "Cuenta");
    //}

}

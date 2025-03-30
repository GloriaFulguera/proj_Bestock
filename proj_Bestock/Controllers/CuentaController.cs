﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using proj_Bestock.Models;
using System.Security.Claims;
using proj_Bestock.Services;

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
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Usuario model)
        {
            bool rta = _usuarioRepo.RegistrarUsuario(model);
            // Redirigir al login después del registro
            if (rta)
                return RedirectToAction("Login");
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario model) // Ahora recibe Usuario directamente
        {
            Usuario rta = _usuarioRepo.AutenticarUsuario(model.Email, model.UserPass);
            if (rta != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

    }
}

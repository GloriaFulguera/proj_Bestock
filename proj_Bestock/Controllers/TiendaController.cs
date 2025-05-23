﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Models;
using proj_Bestock.Services;

namespace proj_Bestock.Controllers
{
    [Authorize]
    public class TiendaController : Controller
    {
        private readonly TiendaService _tiendaService;

        public TiendaController(TiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioLogueado") != "true")
            {
                // Si no hay sesión, redirigimos al login
                return RedirectToAction("Login", "Cuenta");
            }
            var _model = new AdmTiendaViewModel
            {
                Categorias = _tiendaService.ObtenerCategorias(),
                Productos = _tiendaService.ObtenerProductos()
            };
            return View("AdmTienda", _model);
        }
        [HttpPost]
        public IActionResult AgregarCategoria(Categoria model)
        {
            _tiendaService.AgregarCategoria(model);
            return Index();
        }
        public IActionResult EditarCategoria(Categoria nuevaCat)
        {
            _tiendaService.EditarCategoria(nuevaCat);
            return Index();
        }
        public IActionResult Eliminar(int id) {
            _tiendaService.EliminarCategoria(id);
            return Index();
        }

        public IActionResult CargarProductos()
        {
            return Index();
        }

        public IActionResult ProductoNuevo()
        {
            ViewBag.Categorias=_tiendaService.ObtenerCategorias();
            return View("ProductoNuevo");
        }
        [HttpPost]
        public IActionResult AgregarProducto(Producto model) {
            bool resultado=_tiendaService.AgregarProducto(model);
            return Index();
        }
        public IActionResult EliminarProducto(int id)
        {
            _tiendaService.EliminarProducto(id);
            return Index();
        }
        public IActionResult EditarProducto(int id)
        {
            var producto=_tiendaService.ObtenerProducto(id);
            ViewBag.Categorias = _tiendaService.ObtenerCategorias();
            return View("ProductoNuevo",producto);
        }
    }
}

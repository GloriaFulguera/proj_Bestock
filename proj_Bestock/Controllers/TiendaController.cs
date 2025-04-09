using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Models;
using proj_Bestock.Services;

namespace proj_Bestock.Controllers
{
    public class TiendaController : Controller
    {
        private readonly TiendaService _tiendaService;
        public TiendaController(TiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }
        public IActionResult Index()
        {
            var categorias = _tiendaService.ObtenerCategorias();
            return View("AdmTienda",categorias);
        }
        [HttpPost]
        public IActionResult AgregarCategoria(Categoria model)
        {
            _tiendaService.AgregarCategoria(model);
            var categorias = _tiendaService.ObtenerCategorias();
            return View("AdmTienda", categorias);
        }
        public IActionResult EditarCategoria(Categoria nuevaCat)
        {
            _tiendaService.EditarCategoria(nuevaCat);
            var categorias = _tiendaService.ObtenerCategorias();
            return View("AdmTienda", categorias);
        }
        public IActionResult Eliminar(int id) {
            _tiendaService.EliminarCategoria(id);
            var categorias = _tiendaService.ObtenerCategorias();
            return View("AdmTienda", categorias);
        }
    }
}

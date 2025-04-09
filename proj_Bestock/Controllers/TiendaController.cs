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
        public IActionResult EditarCategoria(Categoria nueva)
        {
            var categorias = _tiendaService.ObtenerCategorias();
            return View("AdmTienda", categorias);
        }
    }
}

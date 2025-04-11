using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Models;
using proj_Bestock.Services;

namespace proj_Bestock.Controllers
{
    public class TiendaController : Controller
    {
        private readonly TiendaService _tiendaService;
        //AdmTiendaViewModel _model;
        public TiendaController(TiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }
        public IActionResult Index()
        {
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
            //var categorias = _tiendaService.ObtenerCategorias();
            return Index();
        }
        public IActionResult EditarCategoria(Categoria nuevaCat)
        {
            _tiendaService.EditarCategoria(nuevaCat);
            //var categorias = _tiendaService.ObtenerCategorias();
            return Index();
        }
        public IActionResult Eliminar(int id) {
            _tiendaService.EliminarCategoria(id);
            //var categorias = _tiendaService.ObtenerCategorias();
            return Index();
        }

        public IActionResult CargarProductos()
        {
            //var productos=_tiendaService.ObtenerProductos();
            return Index();
        }

        public IActionResult ProductoNuevo()
        {
            ViewBag.Categorias=_tiendaService.ObtenerCategorias();
            return View("ProductoNuevo");
        }
        [HttpPost]
        public IActionResult AgregarProducto(Producto model) {
            //var categorias = _tiendaService.ObtenerCategorias();
            bool resultado=_tiendaService.AgregarProducto(model);
            return Index();
        }
        public IActionResult EliminarProducto(int id)
        {
            _tiendaService.EliminarProducto(id);
            return Index();
        }
    }
}

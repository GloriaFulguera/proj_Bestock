using Microsoft.AspNetCore.Mvc;
using proj_Bestock.Models;
using proj_Bestock.Services;

namespace proj_Bestock.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly TiendaService _tiendaService;
        public CategoriaController(TiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }
        public IActionResult Index()
        {
            return View("_CategoriasPartial");
        }
        
    }
}

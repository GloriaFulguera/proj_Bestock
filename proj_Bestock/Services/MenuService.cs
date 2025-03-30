using Microsoft.EntityFrameworkCore;
using proj_Bestock.Data;
using proj_Bestock.Models;

namespace proj_Bestock.Services
{
    public class MenuService
    {
        private readonly AppDbContext _context;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            //_httpContextAccessor = httpContextAccessor;
        }
        public  List<MenuItem> ObtenerMenu(int rolId)
        {
            return _context.MenuItems
            .Where(m => m.Rol == rolId)
            .ToList();
            //// 1. Verificar si el usuario está autenticado
            //if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return new List<MenuItem>(); // Retorna lista vacía si no está autenticado
            //}

            //// 2. Obtener el email del usuario logueado
            //var email = _httpContextAccessor.HttpContext.User.Identity.Name;

            //// 3. Obtener el usuario y su rol
            //var usuario = _context.Usuarios
            //                .Include(u => u.RolNavigation)
            //                .FirstOrDefault(u => u.Email == email);

            //if (usuario == null || usuario.RolNavigation == null)
            //{
            //    return new List<MenuItem>();
            //}

            //// 4. Obtener los items del menú para ese rol
            //return _context.MenuItems
            //        .Where(m => m.Rol == usuario.Rol)
            //        .ToList();



            //var rolId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("RolId").Value);
            //return _context.MenuItems
            //    .Where(m => m.Rol == rolId)
            //    .OrderBy(m => m.Nombre)
            //    .ToList();
        }
    }
}

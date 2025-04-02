using Microsoft.EntityFrameworkCore;
using proj_Bestock.Data;
using proj_Bestock.Models;

namespace proj_Bestock.Services
{
    public class MenuService
    {
        private readonly AppDbContext _context;

        public MenuService(AppDbContext context)
        {
            _context = context;
        }
        public  List<MenuItem> ObtenerMenu(int rolId)
        {
            return _context.MenuItems
            //.AsNoTracking() // Mejora el rendimiento,
            .Where(m => m.Rol == rolId)
            .ToList();
            
        }
    }
}

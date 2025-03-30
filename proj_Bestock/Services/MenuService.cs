using proj_Bestock.Data;
using proj_Bestock.Models;

namespace proj_Bestock.Services
{
    public class MenuService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public  List<MenuItem> ObtenerMenu()
        {
            var rolId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("RolId").Value);
            return _context.MenuItems
                .Where(m => m.Rol == rolId)
                .OrderBy(m => m.Nombre)
                .ToList();
        }
    }
}

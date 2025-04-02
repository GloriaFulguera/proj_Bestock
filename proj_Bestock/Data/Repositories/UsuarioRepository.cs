using Microsoft.EntityFrameworkCore;
using proj_Bestock.Models;
using System;

namespace proj_Bestock.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context; // Inyectado por ASP.NET Core
        }
        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<MenuItem> GetMenuItemsByRol(int rolId)
        {
            return _context.MenuItems
                .Where(m => m.Rol == rolId)
                .OrderBy(m => m.Nombre)
                .ToList();
        }
    }
}

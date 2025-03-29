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
            _context = context; // ¡Recibe el DbContext por inyección!
        }
        public bool RegistrarUsuario(Usuario usuario)
        {
            // Verificar si el email ya existe
            //if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
            //    return false;

            try
            {
                usuario.HashPassword(usuario.UserPass);
                _context.Usuarios.Add(usuario);
                int affectedRows = _context.SaveChanges(); // Versión síncrona
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        public Usuario AutenticarUsuario(string email, string password)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == email);

            if (usuario == null) return null;

            // Verificar contraseña usando el método de la clase Usuario
            if (!usuario.VerifyPassword(password))
                return null;

            return usuario;
        }
    }
}

using proj_Bestock.Data.Repositories;
using proj_Bestock.Models;

namespace proj_Bestock.Services
{
    public class AutenticaService
    {
        private readonly UsuarioRepository _userRepo;

        public AutenticaService(UsuarioRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            usuario.HashPassword(usuario.UserPass);
            try
            {
                _userRepo.Add(usuario);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Usuario AutenticarUsuario(string email, string password)
        {
            var usuario = _userRepo.GetByEmail(email);
            if (usuario == null || !usuario.VerifyPassword(password))
                return null;

            return usuario;
        }
    }
}

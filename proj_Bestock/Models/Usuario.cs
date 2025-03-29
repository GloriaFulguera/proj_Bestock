using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations.Schema;

namespace proj_Bestock.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string UserPass { get; set; }

        public void HashPassword(string pass)
        {
            // Hashear la contraseña y guardarla en PasswordHash
            UserPass = BCrypt.Net.BCrypt.HashPassword(pass, BCrypt.Net.BCrypt.GenerateSalt());
        }
        public bool VerifyPassword(string pass)
        {
            return BCrypt.Net.BCrypt.Verify(pass, UserPass);
        }
    }
}

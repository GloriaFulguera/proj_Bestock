using proj_Bestock.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace proj_Bestock.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tablas (una línea por modelo):
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

//using Microsoft.EntityFrameworkCore;
//using TuProyecto.Models;  // Asegúrate de que este using apunte a tus modelos

//public class AppDbContext : DbContext
//{
//    // Constructor que recibe las opciones de configuración
//    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//    {
//    }

//    // DbSet para cada modelo/tabla
//    public DbSet<Usuario> Usuarios { get; set; }

//    // Configuraciones adicionales (opcional)
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        // Ejemplo: Hacer que el Email sea único
//        modelBuilder.Entity<Usuario>()
//            .HasIndex(u => u.Email)
//            .IsUnique();

//        // Si usas fechas de creación/actualización automáticas:
//        modelBuilder.Entity<Usuario>()
//            .Property(u => u.FechaCreacion)
//            .HasDefaultValueSql("GETDATE()");
//    }
//}
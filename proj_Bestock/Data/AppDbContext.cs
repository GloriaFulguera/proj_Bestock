﻿using proj_Bestock.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace proj_Bestock.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tablas:
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Rol como entidad principal
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(r => r.Id_Rol); 
                entity.Property(r => r.Nombre).IsRequired();
            });

            // Configuración de la relación MenuItem → Rol
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.RolNavigation)     // Un MenuItem tiene UN Rol
                .WithMany(r => r.MenuItems)        // Un Rol tiene MUCHOS MenuItems
                .HasForeignKey(m => m.Rol)         // La FK es MenuItem.Rol
                .OnDelete(DeleteBehavior.Restrict); // Evita borrado en cascada

            // Si Usuario también tiene relación con Rol:
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.RolNavigation)      // Si tienes esta propiedad
                .WithMany()                        // Si Rol no tiene colección de Usuarios
                .HasForeignKey(u => u.Rol);      // Ajusta según tu estructura

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.Id_categoria);
                //.OnDelete()
        }
    }
}

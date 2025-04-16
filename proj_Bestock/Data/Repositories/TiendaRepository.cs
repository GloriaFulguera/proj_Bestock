using Microsoft.EntityFrameworkCore;
using proj_Bestock.Models;

namespace proj_Bestock.Data.Repositories
{
    public class TiendaRepository
    {
        private readonly AppDbContext _context;
        public TiendaRepository(AppDbContext context)
        {
            _context = context; // Inyectado por ASP.NET Core
        }
        public List<Categoria> ObtenerCat()
        {
            //List<Categoria> categorias= new List<Categoria>();
            
            return _context.Categorias.ToList();
        }
        public void AgregarCat(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        } 
        public void EditarCat(Categoria categoria)
        {
            var actual=_context.Categorias.FirstOrDefault(c=>c.Id_cat==categoria.Id_cat);
            if (actual!=null)
            {
                actual.Nombre=categoria.Nombre;
                _context.SaveChanges();
            }
        }
        public void EliminarCat(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria!=null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
        }

        public List<Producto> ObtenerProductos()
        {
        //    return _context.Productos
        //.Include(p => p.Categoria) // Esto trae los datos de la categoría asociada
        //.ToList();
            return _context.Productos.ToList();
        }
        public void AgregarProducto(Producto prod)
        {
            _context.Productos.Add(prod);
            _context.SaveChanges();
        }
        public void EliminarProducto(int id)
        {
            var producto= _context.Productos.Find(id);
            if(producto!=null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
        public Producto ObtenerProducto(int id)
        {
            var prod = _context.Productos.Find(id);
            if(prod!=null)
            {
                return prod;
            }
            else
            {
                return null;
            }
        }
    }
}

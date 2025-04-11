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
            return _context.Productos.ToList();
        }
        public void AgergarProducto(Producto prod)
        {
            _context.Productos.Add(prod);
            _context.SaveChanges();
        }
    }
}

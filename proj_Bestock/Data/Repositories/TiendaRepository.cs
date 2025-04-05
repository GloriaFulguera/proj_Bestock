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
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias= new List<Categoria>();
            //_context.Categorias.ToList();
            return categorias;
        }
        public void Agregar(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        } 
    }
}

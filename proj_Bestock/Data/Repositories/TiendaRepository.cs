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
        public List<Categoria> Obtener()
        {
            //List<Categoria> categorias= new List<Categoria>();
            
            return _context.Categorias.ToList();
        }
        public void Agregar(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        } 
    }
}

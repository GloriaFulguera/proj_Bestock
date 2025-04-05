using proj_Bestock.Data.Repositories;
using proj_Bestock.Models;

namespace proj_Bestock.Services
{
    public class TiendaService
    {
        private readonly TiendaRepository _categoriaRepo;

        public TiendaService(TiendaRepository categoriaRepo)
        {
            _categoriaRepo = categoriaRepo;
        }
        public bool AgregarCategoria(Categoria modelo)
        {
            try
            {
                _categoriaRepo.Agregar(modelo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

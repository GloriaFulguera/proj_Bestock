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
                _categoriaRepo.AgregarCat(modelo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Categoria> ObtenerCategorias()
        {
            try
            {
                return _categoriaRepo.ObtenerCat();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool EditarCategoria(Categoria categoria)
        {
            try
            {
                _categoriaRepo.EditarCat(categoria);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EliminarCategoria(int id)
        {
            try
            {
                _categoriaRepo.EliminarCat(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

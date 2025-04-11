using proj_Bestock.Data.Repositories;
using proj_Bestock.Models;

namespace proj_Bestock.Services
{
    public class TiendaService
    {
        private readonly TiendaRepository _tiendaRepo;

        public TiendaService(TiendaRepository categoriaRepo)
        {
            _tiendaRepo = categoriaRepo;
        }
        public bool AgregarCategoria(Categoria modelo)
        {
            try
            {
                _tiendaRepo.AgregarCat(modelo);
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
                return _tiendaRepo.ObtenerCat();
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
                _tiendaRepo.EditarCat(categoria);
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
                _tiendaRepo.EliminarCat(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Producto> ObtenerProductos()
        {
            try
            {
                return _tiendaRepo.ObtenerProductos();
            }
            catch (Exception e)
            {
                return new List<Producto>();
            }
        }
        public bool AgregarProducto(Producto prod)
        {
            try
            {
                _tiendaRepo.AgregarProducto(prod);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EliminarProducto(int id)
        {
            try
            {
                _tiendaRepo.EliminarProducto(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace proj_Bestock.Models
{
    public class Categoria
    {
        [Key]
        public int Id_cat { get; set; }
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}

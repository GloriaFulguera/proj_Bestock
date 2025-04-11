namespace proj_Bestock.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int Id_categoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int Cantidad_minima { get; set; }

        public Categoria Categoria { get; set; }
    }
}

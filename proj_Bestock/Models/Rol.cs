namespace proj_Bestock.Models
{
    public class Rol
    {
        public int Id_Rol { get; set; }
        public string Nombre { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}

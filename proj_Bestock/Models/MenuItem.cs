namespace proj_Bestock.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Rol { get; set; }
        public string Dir_img { get; set; }
        public string Redirect { get; set; }

        public Rol RolNavigation { get; set; }
    }
}

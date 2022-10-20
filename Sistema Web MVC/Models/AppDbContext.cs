using Microsoft.EntityFrameworkCore;

namespace Sistema_Web_MVC.Models
{
    public class AppDbContext : DbContext
    {

    }

    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Desripcion { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }
        public string UrlImagen { get; set; }

        public int CategoriaId { get; set; }
    }

    public class Categoria
    {
        public int CategoriaId{ get; set; }
        public string Nombre{ get; set; }
        public string Descripcion{ get; set; }
    }
}

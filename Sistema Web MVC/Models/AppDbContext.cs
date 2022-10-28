using Microsoft.EntityFrameworkCore;

namespace Sistema_Web_MVC.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BackEndV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }
        public string UrlImagen { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }

    public class Categoria
    {
        public int CategoriaId{ get; set; }
        public string Nombre{ get; set; }
        public string Descripcion{ get; set; }
    }
}

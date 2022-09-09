using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_BD.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> tablaItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ItemsDb_BackEndV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}

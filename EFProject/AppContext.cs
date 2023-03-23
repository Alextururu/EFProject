using Microsoft.EntityFrameworkCore;

namespace EFProject
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public string MsSqlConnection => @"Data Source=.\SQLEXPRESS01;Database=EFProject;Trusted_Connection=True;TrustServerCertificate=True";


        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MsSqlConnection);
        }
    }
}

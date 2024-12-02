using ConsoleLibrary.Entitys;
using Microsoft.EntityFrameworkCore;
namespace ConsoleLibrary
{
    public class ConsoleLibraryContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<GenreBook> GenreBooks { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ASROCK-DESKTOP; Database=library;Trusted_Connection=Yes;TrustServerCertificate=true;");
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace HaniasBookstore.Models
{
    public class HaniasBookstoreDbContext : DbContext
    {
        public HaniasBookstoreDbContext(DbContextOptions<HaniasBookstoreDbContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Mopas.Entities
{
    public class MopasDbContext : DbContext
    {
        public MopasDbContext(DbContextOptions options ) : base( options )
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SalesReport> SalesReports{ get; set; }
    }
}

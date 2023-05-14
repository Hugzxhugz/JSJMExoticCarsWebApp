using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Models
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions options) : base(options) 
        { 
            
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

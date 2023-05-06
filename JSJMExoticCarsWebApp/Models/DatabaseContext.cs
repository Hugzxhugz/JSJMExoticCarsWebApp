using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Car> Cars{ get; set; }
    
}
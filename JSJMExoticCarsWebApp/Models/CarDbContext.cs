﻿using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Models;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Car> Cars{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();
    }
    
}
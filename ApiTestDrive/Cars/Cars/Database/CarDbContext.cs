using System;
using Microsoft.EntityFrameworkCore;
using Cars.Database.Models;

namespace Cars.Database;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options): base(options)
    { 
    }

    public DbSet<Car> cars { get; set; } = null!;
}



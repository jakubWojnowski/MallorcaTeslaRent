using MallorcaTeslaRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MallorcaTeslaRent.Infrastructure.Persistence;

public class MallorcaTeslaRentDbContext : DbContext
{
    public MallorcaTeslaRentDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<RentalLocation> RentalLocations { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
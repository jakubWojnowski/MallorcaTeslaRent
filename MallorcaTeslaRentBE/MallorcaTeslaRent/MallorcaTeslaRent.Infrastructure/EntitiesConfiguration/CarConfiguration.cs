using MallorcaTeslaRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorcaTeslaRent.Infrastructure.EntitiesConfiguration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Model).IsRequired();
        builder.Property(c => c.PricePerDay).HasPrecision(10,2).IsRequired();
        builder.HasMany(c => c.Reservations).WithOne(r => r.Car);
    }
}
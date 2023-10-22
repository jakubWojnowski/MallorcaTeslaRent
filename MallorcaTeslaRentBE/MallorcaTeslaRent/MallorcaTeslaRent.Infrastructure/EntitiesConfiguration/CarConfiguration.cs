using MallorcaTeslaRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorcaTeslaRent.Infrastructure.EntitiesConfiguration;

public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Model).IsRequired();
        builder.Property(c => c.PricePerDay).HasPrecision(10,2).IsRequired();
        builder.HasOne(c => c.RentalLocation).WithMany(r => r.Cars);
    }
}
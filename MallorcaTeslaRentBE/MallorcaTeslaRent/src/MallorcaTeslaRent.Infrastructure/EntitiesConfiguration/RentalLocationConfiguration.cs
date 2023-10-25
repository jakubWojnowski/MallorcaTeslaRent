using MallorcaTeslaRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorcaTeslaRent.Infrastructure.EntitiesConfiguration;

public sealed class RentalLocationConfiguration : IEntityTypeConfiguration<RentalLocation>
{
    public void Configure(EntityTypeBuilder<RentalLocation> builder)
    {
        builder.HasKey(rl => rl.Id);
        builder.Property(rl => rl.Name).IsRequired();
        builder.Property(rl => rl.Address).IsRequired();
        builder.HasMany(rl => rl.Cars).WithOne(c => c.RentalLocation).HasForeignKey(c => c.RentalLocationId);
      
    }
}
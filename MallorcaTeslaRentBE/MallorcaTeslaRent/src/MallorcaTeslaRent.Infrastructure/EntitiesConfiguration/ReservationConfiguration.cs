using MallorcaTeslaRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MallorcaTeslaRent.Infrastructure.EntitiesConfiguration;

public sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.StartDate).IsRequired();
        builder.Property(r => r.EndDate).IsRequired();
        builder.Property(p => p.TotalPrice).HasPrecision(10,2);
    }
}
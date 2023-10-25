using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Infrastructure.Persistence;

namespace MallorcaTeslaRent.Infrastructure.Repositories;

public class ReservationRepository : GenericRepository<Reservation, Guid>, IReservationRepository
{
    public ReservationRepository(MallorcaTeslaRentDbContext dbContext) : base(dbContext)
    {
    }
}
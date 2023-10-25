using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Infrastructure.Persistence;

namespace MallorcaTeslaRent.Infrastructure.Repositories;

public class CarRepository : GenericRepository<Car, Guid>, ICarRepository
{
    public CarRepository(MallorcaTeslaRentDbContext dbContext) : base(dbContext)
    {
    }
}
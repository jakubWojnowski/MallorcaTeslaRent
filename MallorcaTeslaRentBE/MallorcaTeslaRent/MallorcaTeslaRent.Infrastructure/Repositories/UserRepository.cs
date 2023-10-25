using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Infrastructure.Persistence;

namespace MallorcaTeslaRent.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User, Guid>
{
    public UserRepository(MallorcaTeslaRentDbContext dbContext) : base(dbContext)
    {
    }
}
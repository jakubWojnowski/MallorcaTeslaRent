using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Infrastructure.Persistence;

namespace MallorcaTeslaRent.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User, Guid>, IUserRepository
{
    public UserRepository(MallorcaTeslaRentDbContext dbContext) : base(dbContext)
    {
    }
}
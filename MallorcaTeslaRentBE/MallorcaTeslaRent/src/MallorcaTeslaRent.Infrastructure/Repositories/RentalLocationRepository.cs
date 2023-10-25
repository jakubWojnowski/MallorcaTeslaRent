using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MallorcaTeslaRent.Infrastructure.Repositories;

public class RentalLocationRepository : GenericRepository<RentalLocation,Guid>, IRentalLocationRepository
{
    private readonly MallorcaTeslaRentDbContext _dbContext;

    public RentalLocationRepository(MallorcaTeslaRentDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<RentalLocation?> GetRentalLocationByNameAsync(string name, CancellationToken ct)
    {
        return await _dbContext.RentalLocations.FirstOrDefaultAsync(x => x.Name == name, ct);
    }
}
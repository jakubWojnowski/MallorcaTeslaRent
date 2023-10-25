using System.Linq.Expressions;
using MallorcaTeslaRent.Domain.Entities;

namespace MallorcaTeslaRent.Domain.Interfaces;

public interface IRentalLocationRepository
{
    Task<RentalLocation?> GetRentalLocationByNameAsync(string name, CancellationToken ct);
    Task<RentalLocation?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<RentalLocation>> GetAllAsync(CancellationToken ct, Expression<Func<RentalLocation, object>>? include = null);
    Task<Guid> AddAsync(RentalLocation entity, CancellationToken ct);
    Task UpdateAsync(RentalLocation entity, CancellationToken ct);
    Task DeleteAsync(RentalLocation entity,  CancellationToken ct);
    Task<RentalLocation?> GetRecordByFilterAsync(Expression<Func<RentalLocation, bool>> filter, CancellationToken ct);
    Task<IEnumerable<RentalLocation?>> GetAllForConditionAsync(Expression<Func<RentalLocation, bool>> filter, CancellationToken ct);
    Task<bool> AnyAsync(Expression<Func<RentalLocation, bool>> predicate, CancellationToken ct);
    
}
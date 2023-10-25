using System.Linq.Expressions;
using MallorcaTeslaRent.Domain.Entities;

namespace MallorcaTeslaRent.Domain.Interfaces;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IQueryable<Car>> GetAllAsync(CancellationToken ct, Expression<Func<Car, object>>? include = null);
    Task<Guid> AddAsync(Car entity, CancellationToken ct);
    Task UpdateAsync(Car entity, CancellationToken ct);
    Task DeleteAsync(Car entity,  CancellationToken ct);
    Task<Car?> GetRecordByFilterAsync(Expression<Func<Car, bool>> filter, CancellationToken ct);
    Task<IEnumerable<Car?>> GetAllForConditionAsync(Expression<Func<Car, bool>> filter, CancellationToken ct);
    Task<bool> AnyAsync(Expression<Func<Car, bool>> predicate, CancellationToken ct);
}
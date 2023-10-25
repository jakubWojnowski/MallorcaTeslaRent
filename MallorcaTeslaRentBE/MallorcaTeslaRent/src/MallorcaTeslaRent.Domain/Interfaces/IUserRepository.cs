using System.Linq.Expressions;
using MallorcaTeslaRent.Domain.Entities;

namespace MallorcaTeslaRent.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IQueryable<User>> GetAllAsync(CancellationToken ct, Expression<Func<User, object>>? include = null);
    Task<Guid> AddAsync(User entity, CancellationToken ct);
    Task UpdateAsync(User entity, CancellationToken ct);
    Task DeleteAsync(User entity,  CancellationToken ct);
    Task<User?> GetRecordByFilterAsync(Expression<Func<User, bool>> filter, CancellationToken ct);
    Task<IEnumerable<User?>> GetAllForConditionAsync(Expression<Func<User, bool>> filter, CancellationToken ct);
    Task<bool> AnyAsync(Expression<Func<User, bool>> predicate, CancellationToken ct);
}
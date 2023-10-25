using System.Linq.Expressions;

namespace MallorcaTeslaRent.Domain.Interfaces;

public interface IGenericRepository<TEntity, in TKey> where TEntity : class
{
    public Task<TEntity?> GetByIdAsync(TKey id, CancellationToken ct);
    public Task<IQueryable<TEntity>> GetAllAsync(CancellationToken ct, Expression<Func<TEntity, object>>? include = null);
    public Task<IEnumerable<TEntity?>> GetAllForConditionAsync(Expression<Func<TEntity, bool>> filter, CancellationToken ct);
    public Task<Guid> AddAsync(TEntity entity, CancellationToken ct);
    public Task UpdateAsync(TEntity entity, CancellationToken ct);
    public Task DeleteAsync(TEntity entity, CancellationToken ct);
    public Task<TEntity?> GetRecordByFilterAsync(Expression<Func<TEntity, bool>>filter, CancellationToken ct);
    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);
}
using System.Linq.Expressions;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MallorcaTeslaRent.Infrastructure.Repositories;

internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
{
    private readonly MallorcaTeslaRentDbContext _dbContext;
    private readonly DbSet<TEntity> _entities;

    public GenericRepository(MallorcaTeslaRentDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbContext.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();

        if (include != null)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }
    public async Task<Guid> AddAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        var property = _dbContext.Entry(entity).Property("Id");
        return (Guid)(property.CurrentValue ?? throw new InvalidOperationException());
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<TEntity?> GetNextRecordAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _entities.Where(filter).FirstOrDefaultAsync();
    }
}
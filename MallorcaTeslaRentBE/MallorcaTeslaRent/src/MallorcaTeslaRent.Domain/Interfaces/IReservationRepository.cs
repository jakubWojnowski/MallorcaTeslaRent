using System.Linq.Expressions;
using MallorcaTeslaRent.Domain.Entities;

namespace MallorcaTeslaRent.Domain.Interfaces;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IQueryable<Reservation>> GetAllAsync(CancellationToken ct, Expression<Func<Reservation, object>>? include = null);
    Task<Guid> AddAsync(Reservation entity, CancellationToken ct);
    Task UpdateAsync(Reservation entity, CancellationToken ct);
    Task DeleteAsync(Reservation entity,  CancellationToken ct);
    Task<Reservation?> GetRecordByFilterAsync(Expression<Func<Reservation, bool>> filter, CancellationToken ct);
    Task<IEnumerable<Reservation?>> GetAllForConditionAsync(Expression<Func<Reservation, bool>> filter, CancellationToken ct);
    Task<bool> AnyAsync(Expression<Func<Reservation, bool>> predicate, CancellationToken ct);
}
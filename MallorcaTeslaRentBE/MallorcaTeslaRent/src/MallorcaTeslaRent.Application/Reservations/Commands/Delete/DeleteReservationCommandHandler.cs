using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Commands.Delete;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IGenericRepository<Reservation, Guid> _reservationRepository;

    public DeleteReservationCommandHandler(IGenericRepository<Reservation,Guid> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken);
        if (reservation is null) throw new InvalidOperationException("Reservation not found");
        await _reservationRepository.DeleteAsync(reservation, cancellationToken);
    }
}
using MallorcaTeslaRent.Application.Reservations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Commands.Update;

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Guid>
{
    private readonly IGenericRepository<Reservation, Guid> _reservationRepository;
    private static readonly ReservationMappings Mapper = new();

    public UpdateReservationCommandHandler(IGenericRepository<Reservation, Guid> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Guid> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken);
        if (reservation is null) throw new InvalidOperationException("Reservation not found");
        var reservationUpdate = Mapper.UpdateReservation( request.ReservationDto, reservation);
        await _reservationRepository.UpdateAsync(reservationUpdate, cancellationToken);
        return reservationUpdate.Id;
    }
}
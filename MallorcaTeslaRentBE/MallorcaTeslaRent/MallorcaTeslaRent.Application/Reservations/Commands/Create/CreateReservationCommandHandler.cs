using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Reservations.Mappings;
using MallorcaTeslaRent.Application.Users.UserContext;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Commands.Create;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IGenericRepository<Reservation, Guid> _reservationRepository;
    private readonly IUserContext _userContext;
    private static readonly ReservationMappings Mapper = new();

    public CreateReservationCommandHandler(IGenericRepository<Reservation,Guid> reservationRepository, IUserContext userContext)
    {
        _reservationRepository = reservationRepository;
        _userContext = userContext;
    }
    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = Mapper.ReservationDtoToReservation(request.ReservationDto);
        reservation.UserId = Guid.Parse(_userContext.GetCurrentUser()?.Id ?? throw new InvalidOperationException("User not found"));
        await _reservationRepository.AddAsync(reservation);
        return reservation.Id;
    }
}
using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Reservations.Mappings;
using MallorcaTeslaRent.Application.Users.UserContext;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.Get;

public class GetReservationByCarNameQueryHandler : IRequestHandler<GetReservationByCarNameQuery, ReservationDto>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICurrentUserService _currentUserService;
    private static readonly ReservationMappings Mapper = new();

    public GetReservationByCarNameQueryHandler(IReservationRepository reservationRepository, ICurrentUserService currentUserService)
    {
        _reservationRepository = reservationRepository;
        _currentUserService = currentUserService;
    }
    public async Task<ReservationDto> Handle(GetReservationByCarNameQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetCurrentUser()?.Id;
        var reservation = await _reservationRepository.GetRecordByFilterAsync(r => r.Car != null && r.Car.Name == request.Name && r.UserId.ToString() == userId, cancellationToken);
        if(reservation is null) throw new NotFoundException("Reservation not found");
        var reservationDto = Mapper.ReservationToReservationDto(reservation);
        return reservationDto;
    }
}
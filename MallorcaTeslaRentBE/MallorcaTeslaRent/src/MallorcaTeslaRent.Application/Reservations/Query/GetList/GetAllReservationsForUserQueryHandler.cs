using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Reservations.Mappings;
using MallorcaTeslaRent.Application.Users.UserContext;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.GetList;

public class GetAllReservationsForUserQueryHandler : IRequestHandler<GetAllReservationsForUserQuery, IEnumerable<ReservationDto>>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICurrentUserService _currentUserService;
    private static readonly ReservationMappings Mapper = new();

    public GetAllReservationsForUserQueryHandler(IReservationRepository reservationRepository,
        ICurrentUserService currentUserService)
    {
        _reservationRepository = reservationRepository;
        _currentUserService = currentUserService;
    }

    public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsForUserQuery request,
        CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.GetCurrentUser()?.Id;
        var reservations =
            await _reservationRepository.GetAllForConditionAsync(r => r.UserId.ToString() == currentUserId,cancellationToken);
        if (reservations is null) throw new NotFoundException("Reservations not found");
        var reservationDtos = Mapper.MapReservationDtosToReservations(reservations);

        return reservationDtos;
    }
}
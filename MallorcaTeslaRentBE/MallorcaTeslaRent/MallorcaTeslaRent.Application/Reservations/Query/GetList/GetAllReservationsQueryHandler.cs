using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Reservations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.GetList;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
{
    private readonly IGenericRepository<Reservation, Guid> _reservationRepository;
    private static readonly ReservationMappings Mapper = new();

    public GetAllReservationsQueryHandler(IGenericRepository<Reservation, Guid> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAllAsync();
        var reservationDtos = Mapper.MapReservationDtosToReservations(reservations);
        return reservationDtos;
    }
}
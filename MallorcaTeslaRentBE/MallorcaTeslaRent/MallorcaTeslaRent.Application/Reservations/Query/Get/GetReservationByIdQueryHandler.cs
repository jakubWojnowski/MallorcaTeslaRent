using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Reservations.Mappings;
using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.Get;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
{
    private readonly IGenericRepository<Reservation, Guid> _reservationRepository;
    private static readonly ReservationMappings Mapper = new();
    public GetReservationByIdQueryHandler(IGenericRepository<Reservation, Guid> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id);
        if (reservation is null) throw new InvalidOperationException("Reservation not found");
         var reservationDto = Mapper.ReservationToReservationDto(reservation);
        return reservationDto;
    }
}
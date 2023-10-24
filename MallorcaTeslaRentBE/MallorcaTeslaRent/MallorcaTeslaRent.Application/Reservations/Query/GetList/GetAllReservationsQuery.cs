using MallorcaTeslaRent.Application.Reservations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.GetList;

public record GetAllReservationsQuery : IRequest<IEnumerable<ReservationDto>>;
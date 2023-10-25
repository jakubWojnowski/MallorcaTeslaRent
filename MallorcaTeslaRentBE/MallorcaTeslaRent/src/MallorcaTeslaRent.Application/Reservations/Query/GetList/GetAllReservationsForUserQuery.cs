using MallorcaTeslaRent.Application.Reservations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.GetList;

public record GetAllReservationsForUserQuery():IRequest<IEnumerable<ReservationDto>>;
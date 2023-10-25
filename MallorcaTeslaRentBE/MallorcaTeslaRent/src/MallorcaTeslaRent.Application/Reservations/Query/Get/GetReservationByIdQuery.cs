using MallorcaTeslaRent.Application.Reservations.Dto;
using MallorcaTeslaRent.Application.Users.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.Get;

public record GetReservationByIdQuery(Guid Id) : IRequest<ReservationDto>;
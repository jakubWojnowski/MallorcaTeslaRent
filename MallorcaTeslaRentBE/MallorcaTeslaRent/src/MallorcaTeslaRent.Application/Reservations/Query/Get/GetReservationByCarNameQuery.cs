using MallorcaTeslaRent.Application.Reservations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Query.Get;

public record GetReservationByCarNameQuery(string Name) : IRequest<ReservationDto>;
using MallorcaTeslaRent.Application.Reservations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Commands.Update;

public record UpdateReservationCommand(ReservationDto ReservationDto, Guid Id) : IRequest<Guid>;
using MallorcaTeslaRent.Application.Reservations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Commands.Create;

public record CreateReservationCommand(ReservationDto ReservationDto) : IRequest<Guid>;
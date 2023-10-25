using MediatR;

namespace MallorcaTeslaRent.Application.Reservations.Commands.Delete;

public record DeleteReservationCommand(Guid Id) : IRequest;
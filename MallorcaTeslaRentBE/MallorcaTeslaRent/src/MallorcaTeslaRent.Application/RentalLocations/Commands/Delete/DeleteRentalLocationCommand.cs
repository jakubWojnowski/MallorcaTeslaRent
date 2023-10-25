using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Delete;

public record DeleteRentalLocationCommand(Guid Id) : IRequest;
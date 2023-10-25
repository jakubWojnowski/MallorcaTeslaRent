using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Delete;

public record DeleteCarCommand(Guid Id) : IRequest;
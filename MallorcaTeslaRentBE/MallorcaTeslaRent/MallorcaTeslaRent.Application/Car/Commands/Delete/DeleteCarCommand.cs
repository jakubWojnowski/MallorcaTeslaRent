using MediatR;

namespace MallorcaTeslaRent.Application.Car.Commands.Delete;

public record DeleteCarCommand(Guid Id) : IRequest;
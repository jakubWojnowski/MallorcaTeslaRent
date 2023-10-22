using MallorcaTeslaRent.Application.Car.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Commands.Update;

public record UpdateCarCommand(CarDto CarDto, Guid Id) : IRequest;
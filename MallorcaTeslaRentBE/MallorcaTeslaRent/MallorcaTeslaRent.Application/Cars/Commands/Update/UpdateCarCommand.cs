using MallorcaTeslaRent.Application.Cars.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Update;

public record UpdateCarCommand(CarDto CarDto, Guid Id) : IRequest;
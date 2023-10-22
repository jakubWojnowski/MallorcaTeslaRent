using MallorcaTeslaRent.Application.Car.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Commands.Create;

public record CreateCarCommand(CarDto CarDto, Guid RentalLocationId) : IRequest<Guid>;

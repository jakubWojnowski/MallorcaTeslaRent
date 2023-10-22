using MallorcaTeslaRent.Application.Cars.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Create;

public record CreateCarCommand(CarDto CarDto, Guid RentalLocationId) : IRequest<Guid>;

using MallorcaTeslaRent.Application.Cars.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Create;

public record CreateCarCommand(AddCarDto AddCarDto, Guid RentalLocationId) : IRequest<Guid>;

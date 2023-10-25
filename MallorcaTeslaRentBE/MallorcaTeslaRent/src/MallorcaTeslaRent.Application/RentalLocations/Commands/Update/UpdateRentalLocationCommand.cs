using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Update;

public record UpdateRentalLocationCommand(RentalLocationDto RentalLocationDto, Guid Id): IRequest<Guid>;
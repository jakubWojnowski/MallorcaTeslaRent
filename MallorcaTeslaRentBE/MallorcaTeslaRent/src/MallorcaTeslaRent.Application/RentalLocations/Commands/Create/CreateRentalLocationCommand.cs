using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Domain.Entities;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Create;

public record CreateRentalLocationCommand(RentalLocationDto RentalLocationDto) : IRequest<Guid>;
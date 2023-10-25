using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.Get;

public record GetRentalLocationByIdQuery(Guid Id) : IRequest<RentalLocationDto>;
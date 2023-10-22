using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.GetList;

public record GetAllRentalLocationsQuery(): IRequest<IEnumerable<RentalLocationDto>>;
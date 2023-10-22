using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.GetList;

public record GetRenatLocationsAndCarsQuery() : IRequest<IEnumerable<RenatLocationAndCarDto>>;
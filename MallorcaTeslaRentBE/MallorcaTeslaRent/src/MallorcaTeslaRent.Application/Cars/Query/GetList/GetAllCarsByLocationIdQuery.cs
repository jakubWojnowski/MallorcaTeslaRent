using MallorcaTeslaRent.Application.Cars.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.GetList;

public record GetAllCarsByLocationIdQuery(Guid LocationId) : IRequest<IEnumerable<CarDto>>;

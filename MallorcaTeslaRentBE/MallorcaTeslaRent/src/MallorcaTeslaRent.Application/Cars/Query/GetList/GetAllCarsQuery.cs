using MallorcaTeslaRent.Application.Cars.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.GetList;

public record GetAllCarsQuery : IRequest<IEnumerable<CarDto>>;

using MallorcaTeslaRent.Application.Car.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Query.GetList;

public record GetAllCarsQuery : IRequest<IEnumerable<CarDto>>;

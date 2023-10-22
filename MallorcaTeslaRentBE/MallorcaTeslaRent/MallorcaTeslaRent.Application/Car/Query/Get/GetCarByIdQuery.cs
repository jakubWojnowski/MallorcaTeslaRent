using MallorcaTeslaRent.Application.Car.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Query.Get;

public record GetCarByIdQuery(Guid Id) : IRequest<CarDto>;

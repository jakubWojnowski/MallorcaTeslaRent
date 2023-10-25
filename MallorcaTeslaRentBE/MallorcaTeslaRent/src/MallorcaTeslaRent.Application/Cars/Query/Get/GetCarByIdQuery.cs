using MallorcaTeslaRent.Application.Cars.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.Get;

public record GetCarByIdQuery(Guid Id) : IRequest<CarDto>;

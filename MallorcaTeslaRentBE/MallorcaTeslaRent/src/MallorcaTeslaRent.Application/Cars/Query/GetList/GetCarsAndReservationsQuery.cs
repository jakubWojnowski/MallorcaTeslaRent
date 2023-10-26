using MallorcaTeslaRent.Application.Cars.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.GetList;

public record GetCarsAndReservationsQuery() : IRequest<IEnumerable<CarAndReservationDto>>;
using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.GetList;

public class GetCarsAndReservationsQueryHandler : IRequestHandler<GetCarsAndReservationsQuery, IEnumerable<CarAndReservationDto>>
{
    private readonly ICarRepository _carRepository;
    private static readonly CarMappings Mapper = new();

    public GetCarsAndReservationsQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<IEnumerable<CarAndReservationDto>> Handle(GetCarsAndReservationsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync(cancellationToken, include: c => c.Reservations);
        var carsAndReservations = Mapper.MapCarAndReservationDtosToCarAndReservations(cars);
        return carsAndReservations;
    }
}
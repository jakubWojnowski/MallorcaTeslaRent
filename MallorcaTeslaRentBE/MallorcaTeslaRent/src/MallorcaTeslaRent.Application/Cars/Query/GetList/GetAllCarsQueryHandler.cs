using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.GetList;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private static readonly CarMappings Mapper = new();

    public GetAllCarsQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<IEnumerable<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync(cancellationToken);
        return Mapper.MapCarDtosToCars(cars);
        
    }
}
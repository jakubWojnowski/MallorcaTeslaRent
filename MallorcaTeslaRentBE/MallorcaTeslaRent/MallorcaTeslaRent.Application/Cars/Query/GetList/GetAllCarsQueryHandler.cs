using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.GetList;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarDto>>
{
    private readonly IGenericRepository<Car, Guid> _carRepository;
    private static readonly CarMappings Mapper = new();

    public GetAllCarsQueryHandler(IGenericRepository<Car, Guid> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<IEnumerable<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync();
        return Mapper.MapCarDtosToCars(cars);
        
    }
}
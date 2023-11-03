using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.GetList;

public class GetAllCarsByLocationIdQueryHandler : IRequestHandler<GetAllCarsByLocationIdQuery, IEnumerable<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private static readonly CarMappings Mapper = new();

    public GetAllCarsByLocationIdQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<IEnumerable<CarDto>> Handle(GetAllCarsByLocationIdQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllForConditionAsync(c=> c.RentalLocationId == request.LocationId,cancellationToken);
        return Mapper.MapCarDtosToCars(cars);
        
    }
}
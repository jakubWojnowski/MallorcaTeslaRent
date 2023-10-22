using MallorcaTeslaRent.Application.Car.Dto;
using MallorcaTeslaRent.Application.Car.Mappings;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Query.GetList;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarDto>>
{
    private readonly IGenericRepository<Domain.Entities.Car, Guid> _genericRepository;
    private static readonly CarMappings _mapper = new();

    public GetAllCarsQueryHandler(IGenericRepository<Domain.Entities.Car, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _genericRepository.GetAllAsync();
        return _mapper.MapCarDtosToCars(cars);
        
    }
}
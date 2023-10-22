using MallorcaTeslaRent.Application.Car.Dto;
using MallorcaTeslaRent.Application.Car.Mappings;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Query.Get;

public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
{
    private readonly IGenericRepository<Domain.Entities.Car, Guid> _genericRepository;
    private static readonly CarMappings _mapper = new();

    public GetCarByIdQueryHandler(IGenericRepository<Domain.Entities.Car, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _genericRepository.GetByIdAsync(request.Id);
        if (car is null) throw new NotFoundException($"Car od id {request.Id} does not exist!!!");
        var carDto = _mapper.MapCarToCarDto(car);
        return carDto;
    }
}
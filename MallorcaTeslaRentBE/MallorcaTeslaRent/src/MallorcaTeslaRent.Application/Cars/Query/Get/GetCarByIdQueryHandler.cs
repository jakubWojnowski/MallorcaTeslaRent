using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Query.Get;

public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
{
    private readonly ICarRepository _carRepository;
    private static readonly CarMappings Mapper = new();

    public GetCarByIdQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);
        if (car is null) throw new NotFoundException($"Car od id {request.Id} does not exist!!!");
        var carDto = Mapper.MapCarToCarDto(car);
        return carDto;
    }
}
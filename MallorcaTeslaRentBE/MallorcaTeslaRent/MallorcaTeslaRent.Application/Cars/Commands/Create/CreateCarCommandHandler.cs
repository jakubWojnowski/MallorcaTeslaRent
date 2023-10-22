using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Domain.Entities;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
{
    private readonly IGenericRepository<Car, Guid> _carRepository;
    private static readonly CarMappings Mapper = new();

    public CreateCarCommandHandler(IGenericRepository<Car,Guid> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car =  Mapper.MapCarDtoToCar(request.CarDto);
        car.RentalLocationId = request.RentalLocationId;
        await _carRepository.AddAsync(car);
        return car.Id;
    }
}
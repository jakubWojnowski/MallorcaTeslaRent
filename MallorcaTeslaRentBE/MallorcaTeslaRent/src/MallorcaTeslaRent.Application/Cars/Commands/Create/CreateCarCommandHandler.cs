using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
{
    private readonly ICarRepository _carRepository;
    private readonly IRentalLocationRepository _rentalLocationRepository;
    private static readonly CarMappings Mapper = new();

    public CreateCarCommandHandler(ICarRepository carRepository, IRentalLocationRepository rentalLocationRepository)
    {
        _carRepository = carRepository;
        _rentalLocationRepository = rentalLocationRepository;
    }
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car =  Mapper.MapCarDtoToCar(request.CarDto);
        var rentalLocation = await _rentalLocationRepository.GetByIdAsync(request.RentalLocationId, cancellationToken);
        if (rentalLocation is null) throw new NotFoundException($"Rental location od id {request.RentalLocationId} does not exist!!!");
        car.RentalLocationId = rentalLocation.Id;
        await _carRepository.AddAsync(car, cancellationToken);
        return car.Id;
    }
}
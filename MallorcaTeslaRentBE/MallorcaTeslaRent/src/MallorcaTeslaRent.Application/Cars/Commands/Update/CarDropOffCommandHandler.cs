using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Update;

public class CarDropOffCommandHandler : IRequestHandler<CarDropOffCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly IRentalLocationRepository _rentalLocationRepository;

    public CarDropOffCommandHandler(ICarRepository carRepository, IRentalLocationRepository rentalLocationRepository)
    {
        _carRepository = carRepository;
        _rentalLocationRepository = rentalLocationRepository;
    }
    public async Task Handle(CarDropOffCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.CarId, cancellationToken);
        var rentalLocation = await _rentalLocationRepository.GetByIdAsync(request.RentalLocationId, cancellationToken);
        if (rentalLocation is null)
        {
            throw new NotFoundException("Rental location not found");
        }
        if (car is null)
        {
            throw new NotFoundException("Car not found");
        }
        
        car.RentalLocationId = rentalLocation.Id;
        await _carRepository.UpdateAsync(car, cancellationToken);
    }
}
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Update;

public class CarDropOffCommandHandler : IRequestHandler<CarDropOffCommand>
{
    private readonly ICarRepository _carRepository;

    public CarDropOffCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task Handle(CarDropOffCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.CarId, cancellationToken);
        if (car is null)
        {
            throw new NotFoundException("Car not found");
        }
        
        car.RentalLocationId = request.RentalLocationId;
        await _carRepository.UpdateAsync(car, cancellationToken);
    }
}
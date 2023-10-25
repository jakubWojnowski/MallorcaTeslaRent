using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
{
    private readonly IGenericRepository<Car, Guid> _carRepository;
    private static readonly CarMappings Mapper = new();

    public UpdateCarCommandHandler(IGenericRepository<Car, Guid> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);
        if (car is null) throw new NotFoundException($"Car od id {request.Id} does not exist!!!");
        var carUpdate = Mapper.UpdateCar(request.CarDto, car);

        await _carRepository.UpdateAsync(carUpdate, cancellationToken);
    }
}
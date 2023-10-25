using MallorcaTeslaRent.Application.Cars.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Cars.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly IGenericRepository<Car, Guid> _carRepository;
    private static readonly CarMappings Mapper = new();

    public DeleteCarCommandHandler(IGenericRepository<Car, Guid> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);
        if (car is null) throw new NotFoundException($"Car od id {request.Id} does not exist!!!");
        await _carRepository.DeleteAsync(car, cancellationToken);
    }
}
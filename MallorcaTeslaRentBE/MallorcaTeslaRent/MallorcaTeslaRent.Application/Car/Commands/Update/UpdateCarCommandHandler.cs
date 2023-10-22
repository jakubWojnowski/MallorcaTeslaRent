using MallorcaTeslaRent.Application.Car.Mappings;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Commands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
{
    private readonly IGenericRepository<Domain.Entities.Car, Guid> _genericRepository;
    private static readonly CarMappings _mapper = new();

    public UpdateCarCommandHandler(IGenericRepository<Domain.Entities.Car, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _genericRepository.GetByIdAsync(request.Id);
        if (car is null) throw new NotFoundException($"Car od id {request.Id} does not exist!!!");
        var carUpdate = _mapper.UpdateCar(request.CarDto, car);

        await _genericRepository.UpdateAsync(carUpdate);
    }
}
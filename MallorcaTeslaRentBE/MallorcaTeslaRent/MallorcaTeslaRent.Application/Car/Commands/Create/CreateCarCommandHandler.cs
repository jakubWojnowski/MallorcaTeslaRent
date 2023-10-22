using MallorcaTeslaRent.Application.Car.Mappings;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Commands.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
{
    private readonly IGenericRepository<Domain.Entities.Car, Guid> _genericRepository;
    private static readonly CarMappings _mapper = new();

    public CreateCarCommandHandler(IGenericRepository<Domain.Entities.Car,Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car =  _mapper.MapCarDtoToCar(request.CarDto);
        car.RentalLocationId = request.RentalLocationId;
        await _genericRepository.AddAsync(car);
        return car.Id;
    }
}
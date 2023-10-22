using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Create;

public class CreateRentalLocationCommandHandler : IRequestHandler<CreateRentalLocationCommand, Guid>
{
    private readonly IGenericRepository<RentalLocation, Guid> _genericRepository;
    private static readonly RentalLocationMappings _mapper = new();

    public CreateRentalLocationCommandHandler(IGenericRepository<RentalLocation, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Guid> Handle(CreateRentalLocationCommand request, CancellationToken cancellationToken)
    {
        var rentalLocation = _mapper.MapRentalLocationDtoToRentalLocation(request.RentalLocationDto);
        if (request.RentalLocationDto.Name == _genericRepository
                .GetNextRecordAsync(n => n.Name == request.RentalLocationDto.Name).Result
                ?.Name) throw new Exception("Rental location already exists");
        await _genericRepository.AddAsync(rentalLocation);
        return rentalLocation.Id;
    }
}
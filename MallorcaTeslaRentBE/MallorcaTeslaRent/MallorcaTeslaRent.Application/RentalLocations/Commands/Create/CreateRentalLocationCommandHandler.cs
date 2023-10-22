using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Create;

public class CreateRentalLocationCommandHandler : IRequestHandler<CreateRentalLocationCommand, Guid>
{
    private readonly IGenericRepository<RentalLocation, Guid> _rentalLocationRepository;
    private static readonly RentalLocationMappings Mapper = new();

    public CreateRentalLocationCommandHandler(IGenericRepository<RentalLocation, Guid> rentalLocationRepository)
    {
        _rentalLocationRepository = rentalLocationRepository;
    }

    public async Task<Guid> Handle(CreateRentalLocationCommand request, CancellationToken cancellationToken)
    {
        var rentalLocation = Mapper.MapRentalLocationDtoToRentalLocation(request.RentalLocationDto);
        if (request.RentalLocationDto.Name == _rentalLocationRepository
                .GetNextRecordAsync(n => n.Name == request.RentalLocationDto.Name).Result
                ?.Name) throw new Exception("Rental location already exists");
        await _rentalLocationRepository.AddAsync(rentalLocation);
        return rentalLocation.Id;
    }
}
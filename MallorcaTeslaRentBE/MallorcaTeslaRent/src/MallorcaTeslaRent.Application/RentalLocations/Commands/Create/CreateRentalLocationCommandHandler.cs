using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Create;

public class CreateRentalLocationCommandHandler : IRequestHandler<CreateRentalLocationCommand, Guid>
{
    private readonly IRentalLocationRepository _rentalLocationRepository;
    private readonly IRentalLocationRepository _repo;
    private static readonly RentalLocationMappings Mapper = new();

    public CreateRentalLocationCommandHandler(IRentalLocationRepository rentalLocationRepository, IRentalLocationRepository repo)
    {
        _rentalLocationRepository = rentalLocationRepository;
        _repo = repo;
    }

    public async Task<Guid> Handle(CreateRentalLocationCommand request, CancellationToken cancellationToken)
    {
        
        //to do validator
        var rentalLocation = Mapper.MapRentalLocationDtoToRentalLocation(request.RentalLocationDto);
        // var rentalLocationEntity = await _rentalLocationRepository
        //     .GetRecordByFilterAsync(n => n.Name == request.RentalLocationDto.Name, cancellationToken);
        
        var rentalLocationEntity = await _repo.GetRentalLocationByNameAsync(request.RentalLocationDto.Name, cancellationToken);
        if (rentalLocationEntity is not null)
            throw new ResourceAlreadyExistException(
                $"Rental location with name: {request.RentalLocationDto.Name} already exists");
        await _rentalLocationRepository.AddAsync(rentalLocation, cancellationToken);
        return rentalLocation.Id;
    }
}
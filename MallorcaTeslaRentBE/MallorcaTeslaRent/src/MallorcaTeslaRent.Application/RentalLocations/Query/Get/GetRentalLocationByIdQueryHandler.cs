using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.Get;

public class GetRentalLocationByIdQueryHandler : IRequestHandler<GetRentalLocationByIdQuery, RentalLocationDto>
{
    private readonly IRentalLocationRepository _rentalLocationRepository;
    private static readonly RentalLocationMappings Mapper = new();

    public GetRentalLocationByIdQueryHandler(IRentalLocationRepository rentalLocationRepository)
    {
        _rentalLocationRepository = rentalLocationRepository;
    }

    public async Task<RentalLocationDto> Handle(GetRentalLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var rentalLocation = await _rentalLocationRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (rentalLocation is null) throw new NotFoundException($"Rental location with id: {request.Id} not found");
        
        return Mapper.MapRentalLocationToRentalLocationDto(rentalLocation);
    }
}
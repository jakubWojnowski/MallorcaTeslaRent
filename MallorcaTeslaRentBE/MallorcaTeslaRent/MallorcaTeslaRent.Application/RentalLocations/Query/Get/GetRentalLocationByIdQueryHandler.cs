using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.Get;

public class GetRentalLocationByIdQueryHandler : IRequestHandler<GetRentalLocationByIdQuery, RentalLocationDto>
{
    private readonly IGenericRepository<RentalLocation, Guid> _renatalLocationRepository;
    private static readonly RentalLocationMappings Mapper = new();

    public GetRentalLocationByIdQueryHandler(IGenericRepository<RentalLocation, Guid> renatalLocationRepository)
    {
        _renatalLocationRepository = renatalLocationRepository;
    }

    public async Task<RentalLocationDto> Handle(GetRentalLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var rentalLocation = await _renatalLocationRepository.GetByIdAsync(request.Id);
        if (rentalLocation is null) throw new NotFoundException($"Rental location with id: {request.Id} not found");
        return Mapper.MapRentalLocationToRentalLocationDto(rentalLocation);
    }
}
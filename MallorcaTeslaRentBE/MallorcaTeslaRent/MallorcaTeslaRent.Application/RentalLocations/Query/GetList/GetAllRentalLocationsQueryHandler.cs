using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.GetList;

public class GetAllRentalLocationsQueryHandler : IRequestHandler<GetAllRentalLocationsQuery, IEnumerable<RentalLocationDto>>
{
    private readonly IGenericRepository<RentalLocation, Guid> _rentalLocationRepository;
    private static readonly RentalLocationMappings Mapper = new();

    public GetAllRentalLocationsQueryHandler(IGenericRepository<RentalLocation, Guid> rentalLocationRepository)
    {
        _rentalLocationRepository = rentalLocationRepository;
    }
    public async Task<IEnumerable<RentalLocationDto>> Handle(GetAllRentalLocationsQuery request, CancellationToken cancellationToken)
    {
        var rentalLocations = await _rentalLocationRepository.GetAllAsync();
        return Mapper.MapRentalLocationDtosToRentalLocations(rentalLocations);
    }
}
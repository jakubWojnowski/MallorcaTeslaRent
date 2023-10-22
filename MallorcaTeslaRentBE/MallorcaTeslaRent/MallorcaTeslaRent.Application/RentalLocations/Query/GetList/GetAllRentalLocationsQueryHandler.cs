using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.GetList;

public class GetAllRentalLocationsQueryHandler : IRequestHandler<GetAllRentalLocationsQuery, IEnumerable<RentalLocationDto>>
{
    private readonly IGenericRepository<RentalLocation, Guid> _genericRepository;
    private static readonly RentalLocationMappings _mapper = new();

    public GetAllRentalLocationsQueryHandler(IGenericRepository<RentalLocation, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<RentalLocationDto>> Handle(GetAllRentalLocationsQuery request, CancellationToken cancellationToken)
    {
        var rentalLocations = await _genericRepository.GetAllAsync();
        return _mapper.MapRentalLocationDtosToRentalLocations(rentalLocations);
    }
}
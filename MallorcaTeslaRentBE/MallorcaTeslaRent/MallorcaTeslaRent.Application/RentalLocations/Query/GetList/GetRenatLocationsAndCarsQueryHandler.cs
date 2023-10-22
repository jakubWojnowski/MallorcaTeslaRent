using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.GetList;

public class GetRenatLocationsAndCarsQueryHandler : IRequestHandler<GetRenatLocationsAndCarsQuery, IEnumerable<RenatLocationAndCarDto>>
{
    private readonly IGenericRepository<RentalLocation, Guid> _genericRepository;
    private static readonly RentalLocationMappings _rentalLocationMappings = new();

    public GetRenatLocationsAndCarsQueryHandler(IGenericRepository<RentalLocation, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<IEnumerable<RenatLocationAndCarDto>> Handle(GetRenatLocationsAndCarsQuery request, CancellationToken cancellationToken)
    {
        var rentalLocations = await _genericRepository.GetAllAsync(include: r => r.Cars);
        var rentalLocationsAndCars = _rentalLocationMappings.MapRenatLocationAndCarDtosToRentalLocations(rentalLocations);
        return rentalLocationsAndCars;
    }
}
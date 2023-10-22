using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.GetList;

public class GetRenatLocationsAndCarsQueryHandler : IRequestHandler<GetRenatLocationsAndCarsQuery, IEnumerable<RenatLocationAndCarDto>>
{
    private readonly IGenericRepository<RentalLocation, Guid> _rentalLocationRepository;
    private static readonly RentalLocationMappings Mapper = new();

    public GetRenatLocationsAndCarsQueryHandler(IGenericRepository<RentalLocation, Guid> rentalLocationRepository)
    {
        _rentalLocationRepository = rentalLocationRepository;
    }
    public async Task<IEnumerable<RenatLocationAndCarDto>> Handle(GetRenatLocationsAndCarsQuery request, CancellationToken cancellationToken)
    {
        var rentalLocations = await _rentalLocationRepository.GetAllAsync(include: r => r.Cars);
        var rentalLocationsAndCars = Mapper.MapRenatLocationAndCarDtosToRentalLocations(rentalLocations);
        return rentalLocationsAndCars;
    }
}
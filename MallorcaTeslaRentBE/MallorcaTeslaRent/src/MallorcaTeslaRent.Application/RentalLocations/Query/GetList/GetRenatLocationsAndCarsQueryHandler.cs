using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.GetList;

public class GetRenatLocationsAndCarsQueryHandler : IRequestHandler<GetRenatLocationsAndCarsQuery, IEnumerable<RenatLocationAndCarDto>>
{
    private readonly IRentalLocationRepository _rentalLocationRepository;
    private static readonly RentalLocationMappings Mapper = new();

    public GetRenatLocationsAndCarsQueryHandler(IRentalLocationRepository rentalLocationRepository)
    {
        _rentalLocationRepository = rentalLocationRepository;
    }
    public async Task<IEnumerable<RenatLocationAndCarDto>> Handle(GetRenatLocationsAndCarsQuery request, CancellationToken cancellationToken)
    {
        var rentalLocations = await _rentalLocationRepository.GetAllAsync(cancellationToken, include: r => r.Cars);
        
        if (rentalLocations is null) throw new NotFoundException("Rental locations not found");
        
        var rentalLocationsAndCars = Mapper.MapRenatLocationAndCarDtosToRentalLocations(rentalLocations);
        return rentalLocationsAndCars;
    }
}
using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MallorcaTeslaRent.Application.RentalLocations.Mappings;
[Mapper]
public partial class RentalLocationMappings
{
    public partial RentalLocation MapRentalLocationDtoToRentalLocation(RentalLocationDto rentalLocationDto);
    public partial RentalLocationDto MapRentalLocationToRentalLocationDto(RentalLocation rentalLocation);
    public partial IEnumerable<RentalLocationDto> MapRentalLocationDtosToRentalLocations(IEnumerable<RentalLocation> rentalLocation);
   [MapProperty(nameof(RentalLocation.Cars), nameof(RenatLocationAndCarDto.Cars))]
    public partial IEnumerable<RenatLocationAndCarDto> MapRenatLocationAndCarDtosToRentalLocations(IEnumerable<RentalLocation> rentalLocation);
    
    public RentalLocation UpdateRentalLocation(RentalLocationDto rentalLocationDto, RentalLocation rentalLocation)
    {
        rentalLocation.Name = rentalLocationDto.Name;
        rentalLocation.Address = rentalLocationDto.Address;
        return rentalLocation;
    }
    
    
}
using MallorcaTeslaRent.Application.RentalLocations.Dto;
using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Query.Get;

public class GetRentalLocationByIdQueryHandler : IRequestHandler<GetRentalLocationByIdQuery, RentalLocationDto>
{
    private readonly IGenericRepository<RentalLocation, Guid> _genericRepository;
    private static readonly RentalLocationMappings _mapper = new();

    public GetRentalLocationByIdQueryHandler(IGenericRepository<RentalLocation, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<RentalLocationDto> Handle(GetRentalLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var rentalLocation = await _genericRepository.GetByIdAsync(request.Id);
        if (rentalLocation is null) throw new NotFoundException($"Rental location with id: {request.Id} not found");
        return _mapper.MapRentalLocationToRentalLocationDto(rentalLocation);
    }
}
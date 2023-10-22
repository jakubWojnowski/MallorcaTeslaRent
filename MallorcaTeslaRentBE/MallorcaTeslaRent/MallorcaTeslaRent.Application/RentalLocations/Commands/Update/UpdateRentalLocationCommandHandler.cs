using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Update;

public class UpdateRentalLocationCommandHandler : IRequestHandler<UpdateRentalLocationCommand, Guid>
{
    private readonly IGenericRepository<RentalLocation, Guid> _rentalLocationRepository;
    private static readonly RentalLocationMappings Mapper = new();

    public UpdateRentalLocationCommandHandler(IGenericRepository<RentalLocation, Guid> rentalLocationRepository)
    {
        _rentalLocationRepository = rentalLocationRepository;
    }

    public async Task<Guid> Handle(UpdateRentalLocationCommand request, CancellationToken cancellationToken)
    {
        var rentalLocation = await _rentalLocationRepository.GetByIdAsync(request.Id);
        if (rentalLocation is null) throw new NotFoundException($"Rental location with id: {request.Id} not found");
        var updatedRentalLocation = Mapper.UpdateRentalLocation(request.RentalLocationDto, rentalLocation);
        await _rentalLocationRepository.UpdateAsync(updatedRentalLocation);
        return request.Id;
    }
}
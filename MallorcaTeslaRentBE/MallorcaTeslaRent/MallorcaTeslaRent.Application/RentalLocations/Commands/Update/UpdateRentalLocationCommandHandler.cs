using MallorcaTeslaRent.Application.RentalLocations.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Update;

public class UpdateRentalLocationCommandHandler : IRequestHandler<UpdateRentalLocationCommand, Guid>
{
    private readonly IGenericRepository<RentalLocation, Guid> _genericRepository;
    private static readonly RentalLocationMappings _mapper = new();

    public UpdateRentalLocationCommandHandler(IGenericRepository<RentalLocation, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Guid> Handle(UpdateRentalLocationCommand request, CancellationToken cancellationToken)
    {
        var rentalLocation = await _genericRepository.GetByIdAsync(request.Id);
        if (rentalLocation is null) throw new NotFoundException($"Rental location with id: {request.Id} not found");
        var updatedRentalLocation = _mapper.UpdateRentalLocation(request.RentalLocationDto, rentalLocation);
        await _genericRepository.UpdateAsync(updatedRentalLocation);
        return request.Id;
    }
}
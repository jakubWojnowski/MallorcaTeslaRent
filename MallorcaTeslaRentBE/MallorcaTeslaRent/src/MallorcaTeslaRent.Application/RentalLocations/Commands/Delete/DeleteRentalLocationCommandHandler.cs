using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Delete;

public class DeleteRentalLocationCommandHandler : IRequestHandler<DeleteRentalLocationCommand>
{
    private readonly IRentalLocationRepository _rentalLocationRepository;

    public DeleteRentalLocationCommandHandler(IRentalLocationRepository rentalLocationRepository)
    {
        _rentalLocationRepository = rentalLocationRepository;
    }
    public async Task Handle(DeleteRentalLocationCommand request, CancellationToken cancellationToken)
    {
       var rentalLocation = await _rentalLocationRepository.GetByIdAsync(request.Id, cancellationToken);
       
       if (rentalLocation is null) throw new NotFoundException($"Rental location with id: {request.Id} not found");
       
       await _rentalLocationRepository.DeleteAsync(rentalLocation, cancellationToken);
    }
}
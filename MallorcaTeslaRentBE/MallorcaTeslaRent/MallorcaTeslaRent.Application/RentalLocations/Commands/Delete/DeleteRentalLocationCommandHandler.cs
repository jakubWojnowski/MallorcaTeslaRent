using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.RentalLocations.Commands.Delete;

public class DeleteRentalLocationCommandHandler : IRequestHandler<DeleteRentalLocationCommand>
{
    private readonly IGenericRepository<RentalLocation, Guid> _genericRepository;

    public DeleteRentalLocationCommandHandler(IGenericRepository<RentalLocation, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(DeleteRentalLocationCommand request, CancellationToken cancellationToken)
    {
       var rentalLocation = await _genericRepository.GetByIdAsync(request.Id);
       if (rentalLocation is null) throw new NotFoundException($"Rental location with id: {request.Id} not found");
      await _genericRepository.DeleteAsync(rentalLocation);
    }
}
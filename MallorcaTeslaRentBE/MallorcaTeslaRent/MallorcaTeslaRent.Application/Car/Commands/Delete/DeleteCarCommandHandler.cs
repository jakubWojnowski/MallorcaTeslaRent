using MallorcaTeslaRent.Application.Car.Mappings;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Car.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly IGenericRepository<Domain.Entities.Car, Guid> _genericRepository;
    private static readonly CarMappings _mapper = new();

    public DeleteCarCommandHandler(IGenericRepository<Domain.Entities.Car, Guid> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _genericRepository.GetByIdAsync(request.Id);
        if (car is null) throw new NotFoundException($"Car od id {request.Id} does not exist!!!");
        await _genericRepository.DeleteAsync(car);
    }
}
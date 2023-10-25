using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IGenericRepository<User, Guid> _userRepository;

    public DeleteUserCommandHandler(IGenericRepository<User, Guid> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null) throw new NotFoundException($"User od id {request.Id} does not exist!!!");
        await _userRepository.DeleteAsync(user,cancellationToken);
    }
}
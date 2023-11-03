using MallorcaTeslaRent.Application.Users.UserContext;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.Delete;

//zaimplementuj mi DeleteOwnAccountCommandHandler ktory usunie konto uzytkownika po id z jego tokenu

public class DeleteOwnAccountCommandHandler : IRequestHandler<DeleteOwnAccountCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public DeleteOwnAccountCommandHandler(IUserRepository userRepository, ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
    }

    public async Task Handle(DeleteOwnAccountCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserService.GetCurrentUser();

        if (currentUser is null)
        {
            throw new NotFoundException("User is not logged in!!!");
        }

        if (!Guid.TryParse(currentUser.Id, out var currentUserId))
        {
            throw new InvalidOperationException("Current user's ID is not a valid Guid.");
        }

        var user = await _userRepository.GetByIdAsync(currentUserId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException($"User of ID {currentUserId} does not exist!!!");
        }

        await _userRepository.DeleteAsync(user, cancellationToken);
        
        await _identityService.Logout();
    }

}
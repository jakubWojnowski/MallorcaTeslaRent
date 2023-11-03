using MallorcaTeslaRent.Application.Users.UserContext;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.logout;

public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, bool>
{
    private readonly IIdentityService _identityService;

    public LogoutUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        
        return await _identityService.Logout();
    }
}
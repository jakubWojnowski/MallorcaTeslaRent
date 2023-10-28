using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.logout;

public record LogoutUserCommand() : IRequest<bool>;
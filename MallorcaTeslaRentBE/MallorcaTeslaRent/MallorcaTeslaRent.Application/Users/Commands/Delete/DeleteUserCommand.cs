using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.Delete;

public record DeleteUserCommand(Guid Id) : IRequest;
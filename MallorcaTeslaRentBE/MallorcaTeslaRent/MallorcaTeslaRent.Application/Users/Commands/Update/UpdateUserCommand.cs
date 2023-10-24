using MallorcaTeslaRent.Application.Users.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.Update;

public record UpdateUserCommand(Guid Id, UpdateUserDto UpdateUserDto) : IRequest;
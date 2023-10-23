using MallorcaTeslaRent.Application.Users.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.Login;

public record LoginUserCommand(LoginUserDto LoginUserDto) : IRequest<string>;
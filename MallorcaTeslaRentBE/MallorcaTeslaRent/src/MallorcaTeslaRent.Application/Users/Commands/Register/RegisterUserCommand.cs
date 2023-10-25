using MallorcaTeslaRent.Application.Users.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.Register;

public record RegisterUserCommand(RegisterUserDto RegisterUserDto) : IRequest;
 
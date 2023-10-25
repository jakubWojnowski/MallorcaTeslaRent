using MallorcaTeslaRent.Application.Users.Mappings;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MallorcaTeslaRent.Application.Users.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IGenericRepository<User, Guid> _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private static readonly UserMappings Mapper = new();

    public RegisterUserCommandHandler(IGenericRepository<User, Guid> userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = Mapper.MapRegisterUserDtoToUser(request.RegisterUserDto);
        var hashedPassword = _passwordHasher.HashPassword(user, request.RegisterUserDto.Password);
        user.HashedPassword = hashedPassword;

        await _userRepository.AddAsync(user, cancellationToken);
    }
}
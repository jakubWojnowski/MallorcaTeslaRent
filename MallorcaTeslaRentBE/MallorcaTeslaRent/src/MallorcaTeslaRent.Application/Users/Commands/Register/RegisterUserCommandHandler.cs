using MallorcaTeslaRent.Application.Users.Mappings;
using MallorcaTeslaRent.Domain.Interfaces;
using MallorcaTeslaRent.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MallorcaTeslaRent.Application.Users.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private static readonly UserMappings Mapper = new();

    public RegisterUserCommandHandler(IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = Mapper.MapRegisterUserDtoToUser(request.RegisterUserDto);
        
        if (user.DateOfBirth == DateTime.MinValue || user.DateOfBirth == DateTime.MaxValue)
        {
            throw new Exception("Invalid date of birth");
        } 
        
        if (DateTime.Now.AddYears(-18) < user.DateOfBirth)
        {
            throw new Exception("User must be above 18 years old");
        }
        
        var userExists = await _userRepository.GetRecordByFilterAsync(u => u.Email == user.Email, cancellationToken);
        if (userExists != null)
        {
            throw new Exception("Email already exists");
        }
        var hashedPassword = _passwordHasher.HashPassword(user, request.RegisterUserDto.Password);
        user.HashedPassword = hashedPassword;

        await _userRepository.AddAsync(user, cancellationToken);
    }
}
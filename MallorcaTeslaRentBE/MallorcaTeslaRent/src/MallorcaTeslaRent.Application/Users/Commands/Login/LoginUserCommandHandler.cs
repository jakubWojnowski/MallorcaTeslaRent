using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MallorcaTeslaRent.Application.Users.Commands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IGenericRepository<User, Guid> _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginUserCommandHandler(IGenericRepository<User, Guid> userRepository, IJwtProvider jwtProvider,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetRecordByFilterAsync(u => u.Email == request.LoginUserDto.Email, cancellationToken) ??
                   throw new Exception("Invalid email or password");
        var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, request.LoginUserDto.Password);

        if (result == PasswordVerificationResult.Failed) throw new Exception("Invalid email or password");


        return _jwtProvider.GenerateJwtToken(user);
    }
}
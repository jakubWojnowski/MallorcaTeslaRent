using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.Mappings;
using MallorcaTeslaRent.Application.Users.UserContext;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Query.Get;

public class GetAccountProfileQueryHandler : IRequestHandler<GetAccountProfileQuery, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;
    private static readonly UserMappings Mapper = new();

    public GetAccountProfileQueryHandler(IUserRepository userRepository, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public async Task<UserDto> Handle(GetAccountProfileQuery request, CancellationToken cancellationToken)
    {
        var user = Guid.TryParse(_currentUserService.GetCurrentUser()?.Id, out var id)
            ? await _userRepository.GetByIdAsync(id, cancellationToken)
            : throw new Exception("User not found");
        if (user is null) throw new NotFoundException($"User does not exist!!!");
        var userDto = Mapper.MapUserToUserDto(user);
        return userDto;
    }
}
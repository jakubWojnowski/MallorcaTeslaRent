using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Query.GetList;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IGenericRepository<User, Guid> _userRepository;
    private static readonly UserMappings Mapper = new();

    public GetAllUsersQueryHandler(IGenericRepository<User,Guid> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return Mapper.UserDtostoUsers(users);
    }
}
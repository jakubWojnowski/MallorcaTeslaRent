using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Query.Get;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IGenericRepository<User, Guid> _userRepository;
    private static readonly UserMappings Mapper = new();

    public GetUserByIdQueryHandler(IGenericRepository<User, Guid> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null) throw new NotFoundException($"User od id {request.Id} does not exist!!!");
        return Mapper.MapUserToUserDto(user);
    }
}
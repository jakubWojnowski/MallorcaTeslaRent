using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.Mappings;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Exceptions;
using MallorcaTeslaRent.Domain.Interfaces;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IGenericRepository<User, Guid> _userRepository;
    private static readonly UserMappings Mapper = new();

    public UpdateUserCommandHandler(IGenericRepository<User, Guid> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user is null) throw new NotFoundException($"User od id {request.Id} does not exist!!!");
        var userUpdate = Mapper.MapUpdateUser(user, request.UpdateUserDto);
        await _userRepository.UpdateAsync(userUpdate);
    }
}
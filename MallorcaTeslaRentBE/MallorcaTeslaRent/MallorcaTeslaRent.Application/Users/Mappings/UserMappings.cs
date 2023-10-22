using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MallorcaTeslaRent.Application.Users.Mappings;
[Mapper]
public partial class UserMappings
{
    public partial User MapRegisterUserDtoToUser(RegisterUserDto registerUserDto);
    public partial RegisterUserDto MapUserToRegisterUserDto(User user);
    
}
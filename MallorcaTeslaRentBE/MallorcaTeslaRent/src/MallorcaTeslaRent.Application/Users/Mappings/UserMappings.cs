using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MallorcaTeslaRent.Application.Users.Mappings;
[Mapper]
public partial class UserMappings
{
    public partial User MapRegisterUserDtoToUser(RegisterUserDto registerUserDto);
    public partial RegisterUserDto MapUserToRegisterUserDto(User user);
    
    public partial User MapUpdateUserDtoToUser(UserDto userDto);
    public partial UserDto MapUserToUserDto(User user);
    public partial IEnumerable<UserDto> UserDtostoUsers(IEnumerable<User> users);

    public User MapUpdateUser(User user, UpdateUserDto updateUserDto)
    {
        user.Name = updateUserDto.Name;
        user.Surname = updateUserDto.Surname;
        user.DateOfBirth = updateUserDto.DateOfBirth;
        return user;
        
    }
    
}
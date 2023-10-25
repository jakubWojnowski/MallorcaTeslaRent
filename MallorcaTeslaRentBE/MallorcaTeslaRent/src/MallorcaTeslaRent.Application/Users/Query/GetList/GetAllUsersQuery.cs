using MallorcaTeslaRent.Application.Users.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Query.GetList;

public record GetAllUsersQuery() : IRequest<IEnumerable<UserDto>>;
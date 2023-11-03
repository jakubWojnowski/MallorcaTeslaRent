using MallorcaTeslaRent.Application.Users.Dto;
using MediatR;

namespace MallorcaTeslaRent.Application.Users.Query.Get;

public record GetAccountProfileQuery() : IRequest<UserDto>;
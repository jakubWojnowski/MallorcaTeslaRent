using MallorcaTeslaRent.Application.Users.Commands.Delete;
using MallorcaTeslaRent.Application.Users.Commands.Login;
using MallorcaTeslaRent.Application.Users.Commands.Register;
using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.Query.Get;
using MallorcaTeslaRent.Application.Users.Query.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslaRent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
    {
        await _mediator.Send(new RegisterUserCommand(registerUserDto));
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        var token = await _mediator.Send(new LoginUserCommand(loginUserDto));
        return Ok(token);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
        return Ok();
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));
        return Ok(user);
    }
    
    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }
}
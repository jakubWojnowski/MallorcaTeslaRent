using MallorcaTeslaRent.Application.Users.Commands.Delete;
using MallorcaTeslaRent.Application.Users.Commands.Login;
using MallorcaTeslaRent.Application.Users.Commands.logout;
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
    
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete()
    {
        await _mediator.Send(new DeleteOwnAccountCommand());
        return NoContent();
    }
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutUserCommand());
        return NoContent();
    }
    
    [HttpGet("Profile")]
    public async Task<IActionResult> Profile()
    {
        var user = await _mediator.Send(new GetAccountProfileQuery());
        return Ok(user);
    }
}
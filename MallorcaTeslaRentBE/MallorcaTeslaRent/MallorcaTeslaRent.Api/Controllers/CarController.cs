using MallorcaTeslaRent.Application.Cars.Commands.Create;
using MallorcaTeslaRent.Application.Cars.Commands.Delete;
using MallorcaTeslaRent.Application.Cars.Commands.Update;
using MallorcaTeslaRent.Application.Cars.Dto;
using MallorcaTeslaRent.Application.Cars.Query.Get;
using MallorcaTeslaRent.Application.Cars.Query.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslaRent.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("rentalLocation/{id}")]
    public async Task<ActionResult> Create([FromBody] CarDto carDto, [FromRoute] Guid id)
    {
        var carId = await _mediator.Send(new CreateCarCommand(carDto, id));
        return Created($"api/car/{carId}", carId);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var car = await _mediator.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }

    [HttpGet("cars")]
    public async Task<ActionResult> GetAll()
    {
        var cars = await _mediator.Send(new GetAllCarsQuery());
        return Ok(cars);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteCarCommand(id));
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] CarDto carDto)
    {
        await _mediator.Send(new UpdateCarCommand(carDto, id));
        return NoContent();
    }
}
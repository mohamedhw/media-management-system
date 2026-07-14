using DCL.Application.Actors.Commands;
using DCL.Application.Actors.Models;
using DCL.Application.Actors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DCL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActorController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? name) =>
        Ok(await _mediator.Send(new GetActorsQuery(name)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateActorDto dto)
    {
        var id = await _mediator.Send(new CreateActorCommand { Data = dto });
        return CreatedAtAction(nameof(GetAll), new { id }, new { id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id) =>
        Ok(await _mediator.Send(new GetActorByIdQuery(id)));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromForm] UpdateActorDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");
        await _mediator.Send(new UpdateActorCommand { Data = dto });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteActorCommand(id));
        return NoContent();
    }

    public record ActorUpsertDto(string Name);
}

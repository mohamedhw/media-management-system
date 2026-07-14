using DCL.Application.Media;
using DCL.Application.Media.Commands.CreateMedia;
using DCL.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DCL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LKPSController : ControllerBase
{
    private readonly IMediator _mediator;

    public LKPSController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Get([FromBody] GetLKP dto)
    {
        var res = await _mediator.Send(dto);
        return Ok(res);
    }
}

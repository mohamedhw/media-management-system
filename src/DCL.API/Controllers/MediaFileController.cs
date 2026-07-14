using DCL.Application.MediaFiles;
using DCL.Application.MediaFiles.Commands;
using DCL.Application.MediaFiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DCL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaFileController : ControllerBase
{
    private readonly IMediator _mediator;

    public MediaFileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add a single file copy (video, audio, or single image).
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<GetMediaFileDto>> Add([FromBody] AddMediaFileDto dto)
    {
        var result = await _mediator.Send(new AddMediaFileCommand { File = dto });
        return CreatedAtAction(nameof(GetByMedia), new { mediaId = result.MediaId }, result);
    }

    /// <summary>
    /// Add many image files at once (gallery / image set).
    /// All images share the same StorageDevice, FileFormat, and base directory.
    /// </summary>
    [HttpPost("batch")]
    public async Task<ActionResult<List<GetMediaFileDto>>> AddBatch(
        [FromBody] AddMediaFileBatchCommand command
    )
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Get all file copies for a media item.
    /// </summary>
    [HttpGet("{mediaId:long}")]
    public async Task<ActionResult<List<GetMediaFileDto>>> GetByMedia(long mediaId)
    {
        var result = await _mediator.Send(new GetMediaFilesQuery { MediaId = mediaId });
        return Ok(result);
    }
}

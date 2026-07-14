using DCL.Application.Media;
using DCL.Application.Media.Commands.CreateMedia;
using DCL.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DCL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _env;

    public MediaController(IMediator mediator, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _env = env;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateMediaRequest dto)
    {
        string? imagePath = null;

        if (dto.CoverImage != null)
        {
            imagePath = await FileHelper.SaveFileAsync(
                dto.CoverImage,
                _env.WebRootPath, // usually wwwroot
                "images"
            );
        }

        var command = new CreateMediaCommand
        {
            Title = dto.Title,
            OriginalTitle = dto.OriginalTitle,
            Description = dto.Description,
            MediaTypeId = dto.MediaTypeId,
            AgeRatingId = dto.AgeRatingId,
            IsAdultsId = dto.IsAdutlsId,
            ReleaseYear = dto.ReleaseYear,
            Rating = dto.Rating,
            CoverImagePath = imagePath,
            Notes = dto.Notes,
            Tags = dto.Tags,
            ActorIds = dto.ActorIds,
        };

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }

    [HttpPost("GETByFilter")]
    public async Task<IActionResult> GETByFilter([FromBody] GetMediaByFilterQuery query)
    {
        var res = await _mediator.Send(query);
        return Ok(res);
    }

    [HttpPost("GETDetails")]
    public async Task<IActionResult> GETDetails([FromBody] GetMediaDetailQuery query)
    {
        var res = await _mediator.Send(query);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GetMediaDetailDto>> Update(long id, UpdateMediaCommand command)
    {
        if (id != command.Media.Id)
            return BadRequest("ID mismatch");

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    public class CreateMediaRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? OriginalTitle { get; set; }
        public string? Description { get; set; }
        public long MediaTypeId { get; set; }
        public long? AgeRatingId { get; set; }
        public int? IsAdutlsId { get; set; }
        public int? ReleaseYear { get; set; }
        public float? Rating { get; set; }
        public string? CoverImagePath { get; set; }

        public IFormFile CoverImage { get; set; }

        public string? Notes { get; set; }
        public List<string> Tags { get; set; } = [];
        public List<long> ActorIds { get; set; } = [];
    }
}

using MediatR;

namespace DCL.Application.Media.Commands.CreateMedia;

public record CreateMediaCommand : IRequest<long>
{
    public string Title { get; init; } = string.Empty;
    public string? OriginalTitle { get; init; }
    public string? Description { get; init; }
    public long MediaTypeId { get; init; }
    public long? AgeRatingId { get; init; }
    public int? IsAdultsId { get; init; }
    public int? ReleaseYear { get; init; }
    public float? Rating { get; init; }
    public string? CoverImagePath { get; init; }
    public string? Notes { get; init; }

    public List<long> ActorIds { get; init; } = [];
    public List<string> Tags { get; init; } = new List<string>();
}

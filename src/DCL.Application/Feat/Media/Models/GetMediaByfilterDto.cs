namespace DCL.Application.Media;

public class GetMediaByFilterDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public string? Description { get; set; }

    public string MediaType { get; set; } = string.Empty;
    public string? AgeRating { get; set; }

    public int? IsAdultsId { get; set; }
    public int? ReleaseYear { get; set; }
    public float? Rating { get; set; }

    public string? CoverImagePath { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsWatched { get; set; }
    public string? Notes { get; set; }

    public List<string> Genres { get; set; } = [];
    public List<string> Tags { get; set; } = [];

    public List<ActorDto> Actors { get; set; } = [];
}

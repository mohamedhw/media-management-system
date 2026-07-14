namespace DCL.Application.Media;

public class CreateTagsDto
{
    public string Name { get; set; } = string.Empty;
}

public class CreateMediaDto
{
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public string? Description { get; set; }
    public long MediaTypeId { get; set; }
    public long? AgeRatingId { get; set; }
    public int? IsAdultsId { get; set; }
    public int? ReleaseYear { get; set; }
    public float? Rating { get; set; }
    public string? CoverImagePath { get; set; }
    public byte[] CoverImage { get; set; }
    public string? Notes { get; set; }
    public List<CreateTagsDto> Tags { get; set; } = new List<CreateTagsDto>();
}

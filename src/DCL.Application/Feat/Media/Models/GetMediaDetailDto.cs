namespace DCL.Application.Media;

public class ActorDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class TagDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CountryDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class MediaFileDto
{
    public long Id { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public long? QualityId { get; set; }
    public string? Quality { get; set; }
    public long? Size { get; set; }
}

public class MediaThumbnailDto
{
    public long Id { get; set; }
    public string ThumbnailPath { get; set; } = string.Empty;
}

public class MediaTranslationDto
{
    public long Id { get; set; }
    public string Language { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Description { get; set; }
}

public class GetMediaDetailDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public string? Description { get; set; }

    // public string MediaType { get; set; } = string.Empty;
    public long MediaTypeId { get; set; }
    public string MediaTypeName { get; set; }

    // public string? AgeRating { get; set; }

    public long? AgeRatingId { get; set; }
    public string? AgeRatingName { get; set; }
    public int? IsAdultsId { get; set; }

    public int? ReleaseYear { get; set; }
    public float? Rating { get; set; }

    public string? CoverImagePath { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsWatched { get; set; }
    public string? Notes { get; set; }

    public List<string> Genres { get; set; } = [];

    public List<ActorDto> Actors { get; set; } = [];
    public List<TagDto> Tag { get; set; } = [];
    public List<CountryDto> Countries { get; set; } = [];
    public List<MediaFileDto> Files { get; set; } = [];
    public List<MediaThumbnailDto> Thumbnails { get; set; } = [];
    public List<MediaTranslationDto> Translations { get; set; } = [];
}

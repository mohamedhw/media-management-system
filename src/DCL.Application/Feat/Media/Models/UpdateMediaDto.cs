namespace DCL.Application.Media;

public class CreateMediaFileDto
{
    public string FilePath { get; set; } = string.Empty;
    public string? Quality { get; set; }
    public long? Size { get; set; }
}

public class CreateMediaThumbnailDto
{
    public string ThumbnailPath { get; set; } = string.Empty;
}

public class CreateMediaTranslationDto
{
    public string Language { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Description { get; set; }
}

public class UpdateMediaDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public string? Description { get; set; }
    public long MediaTypeId { get; set; }
    public long? AgeRatingId { get; set; }
    public int? IsAdultsId { get; set; }
    public int? ReleaseYear { get; set; }
    public float? Rating { get; set; }
    public string? CoverImagePath { get; set; }
    public bool IsWatched { get; set; }
    public string? Notes { get; set; }
    public List<long> ActorIds { get; set; } = [];
    public List<int> CountryIds { get; set; } = [];

    public List<CreateMediaFileDto> Files { get; set; } = [];
    public List<CreateMediaTranslationDto> Translations { get; set; } = [];
    public List<CreateMediaThumbnailDto> Thumbnails { get; set; } = [];

    // Details (only one will be used depending on MediaType)
    public UpdateAdultDetailDto? AdultDetail { get; set; }
    public UpdateMovieDetailDto? MovieDetail { get; set; }

    // public UpdateSeriesDetailDto? SeriesDetail { get; set; }
    // public UpdateMusicDetailDto? MusicDetail { get; set; }
    // public UpdateGameDetailDto? GameDetail { get; set; }

    // Many-to-many
    public List<long> GenreIds { get; set; } = new();
    public List<long> TagIds { get; set; } = new();
}

public class UpdateAdultDetailDto
{
    public string Title { get; set; } = string.Empty;
}

public class UpdateMovieDetailDto
{
    public string? Director { get; set; }
    public int? Runtime { get; set; }
    public string? ImdbId { get; set; }
    public string? CountryOfOrigin { get; set; }
}

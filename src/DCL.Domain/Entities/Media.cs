namespace DCL.Domain.Entities;

public class Media
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
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    public bool IsWatched { get; set; }
    public string? Notes { get; set; }

    // Navigation
    public MediaType MediaType { get; set; } = null!;
    public AgeRating? AgeRating { get; set; }
    public AdultDetail? AdultDetail { get; set; }
    public MovieDetail? MovieDetail { get; set; }
    public SeriesDetail? SeriesDetail { get; set; }
    public MusicDetail? MusicDetail { get; set; }
    public GameDetail? GameDetail { get; set; }
    public IsAdult? isAdult { get; set; }

    public ICollection<MediaFile> Files { get; set; } = [];
    public ICollection<MediaThumbnail> Thumbnails { get; set; } = [];
    public ICollection<MediaTranslation> Translations { get; set; } = [];
    public ICollection<MediaGenre> Genres { get; set; } = [];
    public ICollection<MediaTag> Tags { get; set; } = [];
    public ICollection<MediaCountry> MediaCountries { get; set; } = [];
    public ICollection<MediaActor> Actors { get; set; } = [];
}

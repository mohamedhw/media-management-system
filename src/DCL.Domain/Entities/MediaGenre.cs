namespace DCL.Domain.Entities;

public class MediaGenre
{
    public long MediaId { get; set; }
    public long GenreId { get; set; }

    // Navigation
    public Media Media { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
}

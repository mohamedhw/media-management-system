namespace DCL.Domain.Entities;

public class MovieDetail
{
    public long Id { get; set; }
    public string? Director { get; set; }
    public int? Runtime { get; set; }
    public string? ImdbId { get; set; }
    public string? CountryOfOrigin { get; set; }

    public long MediaId { get; set; }
    public Media Media { get; set; } = null!;
}

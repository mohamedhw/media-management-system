namespace DCL.Domain.Entities;

public class MediaCountry
{
    public long MediaId { get; set; }
    public Media Media { get; set; } = null!;

    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
}

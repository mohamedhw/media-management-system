namespace DCL.Domain.Entities;

public class MediaTag
{
    public long MediaId { get; set; }
    public long TagId { get; set; }

    // Navigation
    public Media Media { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}

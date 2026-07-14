namespace DCL.Domain.Entities;

public class MediaThumbnail
{
    public long Id { get; set; }
    public long MediaId { get; set; }
    public string FilePath { get; set; } = string.Empty;

    // public long StorageDeviceId { get; set; }
    public string? Type { get; set; } // Cover, Banner, Screenshot, Poster
    public bool IsPrimary { get; set; }

    // Navigation
    public Media Media { get; set; } = null!;
    public StorageDevice StorageDevice { get; set; } = null!;
}

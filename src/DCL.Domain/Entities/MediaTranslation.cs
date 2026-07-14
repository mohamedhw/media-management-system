namespace DCL.Domain.Entities;

public class MediaTranslation
{
    public long Id { get; set; }
    public long MediaId { get; set; }
    public long LanguageId { get; set; }
    public long StorageDeviceId { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public string? Type { get; set; } // Subtitle, Dub, Lyrics

    // Navigation
    public Media Media { get; set; } = null!;
    public Language Language { get; set; } = null!;
    public StorageDevice StorageDevice { get; set; } = null!;
}

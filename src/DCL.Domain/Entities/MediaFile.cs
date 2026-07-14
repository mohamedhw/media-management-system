namespace DCL.Domain.Entities;

public class MediaFile
{
    public long Id { get; set; }
    public long MediaId { get; set; }
    public long StorageDeviceId { get; set; }
    public long FileFormatId { get; set; }

    public string FilePath { get; set; } = string.Empty; // directory path on the drive
    public string? FileName { get; set; } // actual filename
    public long? FileSize { get; set; } // bytes
    public bool IsPrimary { get; set; }
    public string? Notes { get; set; }

    // Navigation
    public Media Media { get; set; } = null!;
    public StorageDevice StorageDevice { get; set; } = null!;
    public FileFormat FileFormat { get; set; } = null!;

    // Type-specific detail — only one will be populated depending on MediaType
    public VideoFileDetail? VideoDetail { get; set; }
    public ImageFileDetail? ImageDetail { get; set; }
}

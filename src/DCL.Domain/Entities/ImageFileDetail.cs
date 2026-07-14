namespace DCL.Domain.Entities;

public class ImageFileDetail
{
    public long Id { get; set; }
    public long MediaFileId { get; set; }

    public int? Width { get; set; }
    public int? Height { get; set; }
    public double? BitDepth { get; set; } // 8, 16, 32
    public string? ColorSpace { get; set; } // sRGB, AdobeRGB, CMYK, Grayscale
    public bool HasAlpha { get; set; }

    // Navigation
    public MediaFile MediaFile { get; set; } = null!;
}

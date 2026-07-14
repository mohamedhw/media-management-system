namespace DCL.Application.MediaFiles;

public class AddMediaFileDto
{
    public long MediaId { get; set; }
    public long StorageDeviceId { get; set; }
    public long FileFormatId { get; set; }

    public string FilePath { get; set; } = string.Empty;
    public string? FileName { get; set; }
    public long? FileSize { get; set; }
    public bool IsPrimary { get; set; }
    public string? Notes { get; set; }

    // Exactly one of these should be set depending on the media type.
    // For Movie / Series / Adult / Music → fill VideoDetail.
    // For Image                          → fill ImageDetail.
    public AddVideoDetailDto? VideoDetail { get; set; }
    public AddImageDetailDto? ImageDetail { get; set; }
}

public class AddVideoDetailDto
{
    public long? QualityId { get; set; }
    public long? ScanTypeId { get; set; }
    public long? FrameRateModeId { get; set; }

    public double BitRate { get; set; }
    public double FrameRate { get; set; }
    public double BitsPerPixelFrame { get; set; }
    public double BitDepth { get; set; }
    public int ReferenceFrame { get; set; }
    public double Duration { get; set; } // seconds
}

public class AddImageDetailDto
{
    public int? Width { get; set; }
    public int? Height { get; set; }
    public double? BitDepth { get; set; }
    public string? ColorSpace { get; set; }
    public bool HasAlpha { get; set; }
}

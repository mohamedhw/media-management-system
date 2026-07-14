namespace DCL.Application.MediaFiles;

public class GetMediaFileDto
{
    public long Id { get; set; }
    public long MediaId { get; set; }
    public string StorageDevice { get; set; } = string.Empty;
    public string FileFormat { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string? FileName { get; set; }
    public long? FileSize { get; set; }
    public bool IsPrimary { get; set; }
    public string? Notes { get; set; }

    public GetVideoDetailDto? VideoDetail { get; set; }
    public GetImageDetailDto? ImageDetail { get; set; }
}

public class GetVideoDetailDto
{
    public string? Quality { get; set; }
    public string? ScanType { get; set; }
    public string? FrameRateMode { get; set; }
    public double BitRate { get; set; }
    public double FrameRate { get; set; }
    public double BitsPerPixelFrame { get; set; }
    public double BitDepth { get; set; }
    public int ReferenceFrame { get; set; }
    public double Duration { get; set; }
}

public class GetImageDetailDto
{
    public int? Width { get; set; }
    public int? Height { get; set; }
    public double? BitDepth { get; set; }
    public string? ColorSpace { get; set; }
    public bool HasAlpha { get; set; }
}

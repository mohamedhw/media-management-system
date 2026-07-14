namespace DCL.Domain.Entities;

public class VideoFileDetail
{
    public long Id { get; set; }
    public long MediaFileId { get; set; }

    public long? QualityId { get; set; }
    public long? ScanTypeId { get; set; }
    public long? FrameRateModeId { get; set; }

    public double BitRate { get; set; }
    public double FrameRate { get; set; }
    public double BitsPerPixelFrame { get; set; }
    public double BitDepth { get; set; }
    public int ReferenceFrame { get; set; }
    public double Duration { get; set; } // seconds

    // Navigation
    public MediaFile MediaFile { get; set; } = null!;
    public Quality? Quality { get; set; }
    public ScanType? ScanType { get; set; }
    public FrameRateMode? FrameRateMode { get; set; }
}

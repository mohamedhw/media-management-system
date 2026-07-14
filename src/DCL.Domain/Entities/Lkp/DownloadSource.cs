namespace DCL.Domain.Entities;

public class DownloadSource
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long? SourceTypeId { get; set; }

    public SourceType? SourceType { get; set; }
}

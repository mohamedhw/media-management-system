namespace DCL.Domain.Entities;

public class StorageDevice
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? MountPath { get; set; }
    public double? TotalSpaceGb { get; set; }
    public double? FreeSpaceGb { get; set; }
}

namespace DCL.Domain.Entities;

public class Quality
{
    public long Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public int? ResolutionW { get; set; }
    public int? ResolutionH { get; set; }
}

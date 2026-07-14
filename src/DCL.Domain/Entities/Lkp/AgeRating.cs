namespace DCL.Domain.Entities;

public class AgeRating
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MinAge { get; set; }
}

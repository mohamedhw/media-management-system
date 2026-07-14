namespace DCL.Domain.Entities;

public class GameDetail
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public long MediaId { get; set; }
    public Media Media { get; set; } = null!;
}

namespace DCL.Domain.Entities;

public class AdultDetail
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public long MediaId { get; set; }
    public Media Media { get; set; } = null!;
}

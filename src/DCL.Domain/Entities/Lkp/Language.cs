namespace DCL.Domain.Entities;

public class Language
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty; // English, Arabic
    public string? Code { get; set; } // en, ar, ja
}

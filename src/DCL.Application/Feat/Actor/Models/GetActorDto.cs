namespace DCL.Application.Actors.Models;

public class GetActorDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int? GenderId { get; set; }

    public string? OriginalName { get; set; }

    public int? CountryId { get; set; }
    public string? CountryName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? BloodType { get; set; }

    public string? Height { get; set; }
    public string? Weight { get; set; }

    public string? BreastSize { get; set; }
    public string? WaistSize { get; set; }
    public string? HipsSize { get; set; }
    public string? CupSize { get; set; }

    public string? ProfileImagePath { get; set; }

    public string? Biography { get; set; }
    public string? Notes { get; set; }

    public string? IMDB { get; set; }
    public string? Instgram { get; set; }
    public string? Twiter { get; set; }
    public string? Facebook { get; set; }
    public string? Riddet { get; set; }
    public string? Website { get; set; }

    public int? IsAdultsId { get; set; }

    public List<string> Tags { get; set; } = [];
}

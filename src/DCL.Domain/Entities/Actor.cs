namespace DCL.Domain.Entities;

public class Actor
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? GenderId { get; set; }
    public string? OriginalName { get; set; } // native script name
    public int? CountryId { get; set; }

    public DateOnly? DateOfBirth { get; set; }
    public string? BloodType { get; set; } // A, B, AB, O

    public string? Height { get; set; } // cm
    public string? Weight { get; set; } // kg

    public string? Measurements { get; set; } // e.g. "105-59-88"
    public string? BreastSize { get; set; } // cm
    public string? WaistSize { get; set; } // cm
    public string? HipsSize { get; set; } // cm
    public string? CupSize { get; set; } // A-K

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

    public Country? Country { get; set; }
    public Gender? Gender { get; set; }
    public IsAdult? isAdult { get; set; }

    // Navigation
    public ICollection<ActorTag> Tags { get; set; } = [];
    public ICollection<MediaActor> MediaActors { get; set; } = [];
}

namespace DCL.Domain.Entities;

public class ActorTag
{
    public long ActorId { get; set; }
    public long TagId { get; set; }

    // Navigation
    public Actor Actor { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}

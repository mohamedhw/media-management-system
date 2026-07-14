namespace DCL.Domain.Entities;

public class MediaActor
{
    public long MediaId { get; set; }
    public long ActorId { get; set; }

    public Media Media { get; set; } = null!;
    public Actor Actor { get; set; } = null!;
}

namespace DCL.Domain.Entities;

public class Tag
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<MediaTag> MediaTags { get; set; } = [];
    public ICollection<ActorTag> ActorTags { get; set; } = [];
}

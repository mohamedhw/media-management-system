using DCL.Application.Common.Interfaces;
using MediatR;

namespace DCL.Application.Media.Commands.CreateMedia;

public class CreateMediaCommandHandler : IRequestHandler<CreateMediaCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateMediaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
    {
        var tagEntities = new List<DCL.Domain.Entities.Tag>();

        foreach (var rawName in request.Tags)
        {
            var tagName = rawName.Trim();
            if (string.IsNullOrEmpty(tagName))
                continue;
            var existingTag = _context.Tags.FirstOrDefault(t => t.Name == tagName);
            if (existingTag == null)
            {
                existingTag = new DCL.Domain.Entities.Tag { Name = tagName };
                _context.Tags.Add(existingTag);
                await _context.SaveChangesAsync(cancellationToken);
            }
            tagEntities.Add(existingTag);
        }

        var media = new DCL.Domain.Entities.Media
        {
            Title = request.Title,
            OriginalTitle = request.OriginalTitle,
            Description = request.Description,
            MediaTypeId = request.MediaTypeId,
            AgeRatingId = request.AgeRatingId,
            IsAdultsId = request.IsAdultsId,
            ReleaseYear = request.ReleaseYear,
            Rating = request.Rating,
            CoverImagePath = request.CoverImagePath,
            Notes = request.Notes,
            DateAdded = DateTime.UtcNow,
            IsWatched = false,
        };

        _context.Media.Add(media);
        await _context.SaveChangesAsync(cancellationToken);

        foreach (var tag in tagEntities)
        {
            _context.MediaTags.Add(
                new DCL.Domain.Entities.MediaTag { MediaId = media.Id, TagId = tag.Id }
            );
        }

        await _context.SaveChangesAsync(cancellationToken);

        foreach (var actorId in request.ActorIds)
        {
            _context.MediaActors.Add(
                new DCL.Domain.Entities.MediaActor { MediaId = media.Id, ActorId = actorId }
            );
        }
        await _context.SaveChangesAsync(cancellationToken);

        return media.Id;
    }
}

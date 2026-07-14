using DCL.Application.Common.Interfaces;
using DCL.Application.Media;
using MediatR;

namespace DCL.Application.Queries;

public class GetMediaDetailQuery : IRequest<GetMediaDetailDto>
{
    public int? id { get; init; }
}

public class GetMediaDetailQueryHandler : IRequestHandler<GetMediaDetailQuery, GetMediaDetailDto>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetMediaDetailDto> Handle(
        GetMediaDetailQuery request,
        CancellationToken cancellationToken
    )
    {
        if (!request.id.HasValue)
            throw new ArgumentException("Id is required.");

        var query = _context
            .Media.Include(m => m.MediaType)
            .Include(m => m.AgeRating)
            .Include(m => m.Genres)
                .ThenInclude(g => g.Genre)
            .Include(m => m.Tags)
                .ThenInclude(t => t.Tag)
            .AsQueryable();

        var result = await query
            .Where(m => m.Id == request.id.Value)
            .Select(m => new GetMediaDetailDto
            {
                Id = m.Id,
                Title = m.Title,
                OriginalTitle = m.OriginalTitle,
                Description = m.Description,
                MediaTypeId = m.MediaTypeId,
                MediaTypeName = m.MediaType.Name,
                AgeRatingId = m.AgeRatingId,
                AgeRatingName = m.AgeRating.Name,
                IsAdultsId = m.IsAdultsId,
                ReleaseYear = m.ReleaseYear,
                Rating = m.Rating,
                CoverImagePath = m.CoverImagePath,
                DateAdded = m.DateAdded,
                IsWatched = m.IsWatched,
                Notes = m.Notes,
                Genres = m.Genres.Select(g => g.Genre.Name).ToList(),
                Tag = m.Tags.Select(t => new TagDto { Id = t.Tag.Id, Name = t.Tag.Name }).ToList(),
                Actors = m
                    .Actors.Select(a => new ActorDto { Id = a.Actor.Id, Name = a.Actor.Name })
                    .ToList(),

                Countries = m
                    .MediaCountries.Select(c => new CountryDto
                    {
                        Id = c.Country.Id,
                        Name = c.Country.Name,
                    })
                    .ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken);

        return result ?? throw new NotFoundException(nameof(Media), request.id.Value);
    }
}

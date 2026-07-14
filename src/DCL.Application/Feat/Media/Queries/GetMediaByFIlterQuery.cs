using DCL.Application.Common.Interfaces;
using DCL.Application.Media;
using MediatR;

namespace DCL.Application.Queries;

public class GetMediaByFilterQuery : IRequest<List<GetMediaByFilterDto>>
{
    public string? Title { get; init; }
    public long? MediaTypeId { get; init; }
    public long? AgeRatingId { get; init; }
    public int? IsAdultsId { get; init; }
    public bool? IsWatched { get; init; }
    public int? ReleaseYearFrom { get; init; }
    public int? ReleaseYearTo { get; init; }
    public long? GenreId { get; init; }
    public long? TagId { get; init; }
}

public class GetMediaByFilterQueryHandler
    : IRequestHandler<GetMediaByFilterQuery, List<GetMediaByFilterDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaByFilterQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetMediaByFilterDto>> Handle(
        GetMediaByFilterQuery request,
        CancellationToken cancellationToken
    )
    {
        var query = _context
            .Media.Include(m => m.MediaType)
            .Include(m => m.AgeRating)
            .Include(m => m.Genres)
                .ThenInclude(g => g.Genre)
            .Include(m => m.Tags)
                .ThenInclude(t => t.Tag)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.Title))
            query = query.Where(m => m.Title.Contains(request.Title));

        if (request.MediaTypeId.HasValue)
            query = query.Where(m => m.MediaTypeId == request.MediaTypeId);

        if (request.AgeRatingId.HasValue)
            query = query.Where(m => m.AgeRatingId == request.MediaTypeId);

        if (request.IsAdultsId.HasValue)
            query = query.Where(m => m.IsAdultsId == request.IsAdultsId);

        if (request.IsWatched.HasValue)
            query = query.Where(m => m.IsWatched == request.IsWatched);

        if (request.ReleaseYearFrom.HasValue)
            query = query.Where(m => m.ReleaseYear >= request.ReleaseYearFrom);

        if (request.ReleaseYearTo.HasValue)
            query = query.Where(m => m.ReleaseYear <= request.ReleaseYearTo);

        if (request.GenreId.HasValue)
            query = query.Where(m => m.Genres.Any(g => g.GenreId == request.GenreId));

        if (request.TagId.HasValue)
            query = query.Where(m => m.Tags.Any(t => t.TagId == request.TagId));

        var result = await query
            .Select(m => new GetMediaByFilterDto
            {
                Id = m.Id,
                Title = m.Title,
                OriginalTitle = m.OriginalTitle,
                Description = m.Description,
                MediaType = m.MediaType.Name,
                AgeRating = m.AgeRating != null ? m.AgeRating.Name : null,
                IsAdultsId = m.IsAdultsId,
                ReleaseYear = m.ReleaseYear,
                Rating = m.Rating,
                CoverImagePath = m.CoverImagePath,
                DateAdded = m.DateAdded,
                IsWatched = m.IsWatched,
                Notes = m.Notes,
                Genres = m.Genres.Select(g => g.Genre.Name).ToList(),
                Tags = m.Tags.Select(t => t.Tag.Name).ToList(),
                Actors = m
                    .Actors.Select(a => new ActorDto { Id = a.Actor.Id, Name = a.Actor.Name })
                    .ToList(),
            })
            .ToListAsync(cancellationToken);
        return result;
    }
}

using DCL.Application.Common.Exceptions;
using DCL.Application.Common.Interfaces;
using DCL.Application.Media;
using DCL.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DCL.Application.Media.Commands.CreateMedia;

public class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, GetMediaDetailDto>
{
    private readonly IApplicationDbContext _context;

    public UpdateMediaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetMediaDetailDto> Handle(
        UpdateMediaCommand request,
        CancellationToken cancellationToken
    )
    {
        var media =
            await _context
                .Media.Include(m => m.AdultDetail)
                .Include(m => m.MovieDetail)
                .Include(m => m.SeriesDetail)
                .Include(m => m.MusicDetail)
                .Include(m => m.GameDetail)
                .Include(m => m.Genres)
                .Include(m => m.Tags)
                .Include(m => m.Actors)
                .Include(m => m.MediaCountries)
                .FirstOrDefaultAsync(m => m.Id == request.Media.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Media), request.Media.Id);

        media.Title = request.Media.Title;
        media.OriginalTitle = request.Media.OriginalTitle;
        media.Description = request.Media.Description;
        media.MediaTypeId = request.Media.MediaTypeId;
        media.AgeRatingId = request.Media.AgeRatingId;
        media.IsAdultsId = request.Media.IsAdultsId;
        media.ReleaseYear = request.Media.ReleaseYear;
        media.Rating = request.Media.Rating;
        media.CoverImagePath = request.Media.CoverImagePath;
        media.IsWatched = request.Media.IsWatched;
        media.Notes = request.Media.Notes;

        await UpdateDetailAsync(media, request.Media, cancellationToken);
        await UpdateGenresAsync(media, request.Media.GenreIds, cancellationToken);
        await UpdateTagsAsync(media, request.Media.TagIds, cancellationToken);
        await UpdateActorsAsync(media, request.Media.ActorIds, cancellationToken);
        await UpdateCountriesAsync(media, request.Media.CountryIds, cancellationToken);

        var dbContext = (DbContext)_context;
        var entries = dbContext
            .ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged)
            .ToList();

        foreach (var entry in entries)
        {
            Console.WriteLine($"[EF] {entry.State} | {entry.Entity.GetType().Name}");
            foreach (
                var prop in entry.Properties.Where(p =>
                    p.IsModified || entry.State == EntityState.Added
                )
            )
                Console.WriteLine($"       {prop.Metadata.Name} = {prop.CurrentValue}");
        }

        await _context.SaveChangesAsync(cancellationToken);

        return await BuildDetailDto(media.Id, cancellationToken);
    }

    private async Task UpdateDetailAsync(
        DCL.Domain.Entities.Media media,
        UpdateMediaDto dto,
        CancellationToken ct
    )
    {
        if (dto.AdultDetail != null)
        {
            if (media.AdultDetail == null)
            {
                media.AdultDetail = new AdultDetail { MediaId = media.Id };
                _context.AdultDetails.Add(media.AdultDetail);
            }
            media.AdultDetail.Title = dto.AdultDetail.Title;
        }
        else if (dto.MovieDetail != null)
        {
            if (media.MovieDetail == null)
            {
                media.MovieDetail = new MovieDetail { MediaId = media.Id };
                _context.MovieDetails.Add(media.MovieDetail);
            }
            media.MovieDetail.Director = dto.MovieDetail.Director;
            media.MovieDetail.Runtime = dto.MovieDetail.Runtime;
            media.MovieDetail.ImdbId = dto.MovieDetail.ImdbId;
            media.MovieDetail.CountryOfOrigin = dto.MovieDetail.CountryOfOrigin;
        }
    }

    private async Task UpdateGenresAsync(
        DCL.Domain.Entities.Media media,
        List<long> newGenreIds,
        CancellationToken ct
    )
    {
        var currentIds = media.Genres.Select(g => g.GenreId).ToHashSet();
        var toAdd = newGenreIds.Except(currentIds).ToList();
        var toRemove = currentIds.Except(newGenreIds).ToList();

        if (toRemove.Any())
            _context.MediaGenres.RemoveRange(media.Genres.Where(g => toRemove.Contains(g.GenreId)));

        foreach (var id in toAdd)
            media.Genres.Add(new MediaGenre { MediaId = media.Id, GenreId = id });
    }

    private async Task UpdateTagsAsync(
        DCL.Domain.Entities.Media media,
        List<long> newTagIds,
        CancellationToken ct
    )
    {
        var currentIds = media.Tags.Select(t => t.TagId).ToHashSet();
        var toAdd = newTagIds.Except(currentIds).ToList();
        var toRemove = currentIds.Except(newTagIds).ToList();

        if (toRemove.Any())
            _context.MediaTags.RemoveRange(media.Tags.Where(t => toRemove.Contains(t.TagId)));

        foreach (var id in toAdd)
            media.Tags.Add(new MediaTag { MediaId = media.Id, TagId = id });
    }

    private async Task UpdateActorsAsync(
        DCL.Domain.Entities.Media media,
        List<long> newActorIds,
        CancellationToken ct
    )
    {
        var validIds = await _context
            .Actors.Where(a => newActorIds.Contains(a.Id))
            .Select(a => a.Id)
            .ToListAsync(ct);

        var invalidIds = newActorIds.Except(validIds).ToList();
        if (invalidIds.Any())
            throw new NotFoundException(nameof(Actor), string.Join(", ", invalidIds));

        var currentIds = media.Actors.Select(a => a.ActorId).ToHashSet();
        var toAdd = validIds.Except(currentIds).ToList();
        var toRemove = currentIds.Except(validIds).ToList();

        if (toRemove.Any())
            _context.MediaActors.RemoveRange(media.Actors.Where(a => toRemove.Contains(a.ActorId)));

        foreach (var id in toAdd)
            _context.MediaActors.Add(new MediaActor { MediaId = media.Id, ActorId = id });
    }

    private async Task UpdateCountriesAsync(
        DCL.Domain.Entities.Media media,
        List<int> newCountryIds,
        CancellationToken ct
    )
    {
        // validate countries exist
        var validIds = await _context
            .Countries.Where(c => newCountryIds.Contains(c.Id))
            .Select(c => c.Id)
            .ToListAsync(ct);

        var invalidIds = newCountryIds.Except(validIds).ToList();
        if (invalidIds.Any())
            throw new NotFoundException(nameof(Country), string.Join(", ", invalidIds));

        var currentIds = media.MediaCountries.Select(c => c.CountryId).ToHashSet();
        var toAdd = validIds.Except(currentIds).ToList();
        var toRemove = currentIds.Except(validIds).ToList();

        if (toRemove.Any())
            _context.MediaCountries.RemoveRange(
                media.MediaCountries.Where(c => toRemove.Contains(c.CountryId))
            );

        foreach (var id in toAdd)
            media.MediaCountries.Add(new MediaCountry { MediaId = media.Id, CountryId = id });
    }

    private async Task<GetMediaDetailDto> BuildDetailDto(long id, CancellationToken ct)
    {
        var media =
            await _context
                .Media.Include(m => m.MediaType)
                .Include(m => m.AgeRating)
                .Include(m => m.Genres)
                    .ThenInclude(g => g.Genre)
                .Include(m => m.Tags)
                    .ThenInclude(t => t.Tag)
                .Include(m => m.Actors)
                    .ThenInclude(a => a.Actor)
                .Include(m => m.MediaCountries)
                    .ThenInclude(c => c.Country)
                .Include(m => m.Files)
                .Include(m => m.Thumbnails)
                .Include(m => m.Translations)
                    .ThenInclude(t => t.Language)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync(ct)
            ?? throw new NotFoundException(nameof(Media), id);

        return new GetMediaDetailDto
        {
            Id = media.Id,
            Title = media.Title,
            OriginalTitle = media.OriginalTitle,
            Description = media.Description,
            MediaTypeId = media.MediaTypeId,
            AgeRatingId = media.AgeRatingId,
            IsAdultsId = media.IsAdultsId,
            ReleaseYear = media.ReleaseYear,
            Rating = media.Rating,
            CoverImagePath = media.CoverImagePath,
            DateAdded = media.DateAdded,
            IsWatched = media.IsWatched,
            Notes = media.Notes,
            Genres = media.Genres.Select(g => g.Genre.Name).ToList(),
            Tag = media.Tags.Select(t => new TagDto { Id = t.Tag.Id, Name = t.Tag.Name }).ToList(),
            Actors = media
                .Actors.Select(a => new ActorDto { Id = a.Actor.Id, Name = a.Actor.Name })
                .ToList(),
            Countries = media
                .MediaCountries.Select(c => new CountryDto
                {
                    Id = c.Country.Id,
                    Name = c.Country.Name,
                })
                .ToList(),
            Files = media
                .Files.Select(f => new MediaFileDto
                {
                    Id = f.Id,
                    FilePath = f.FilePath,
                    Size = f.FileSize,
                })
                .ToList(),
            Thumbnails = media
                .Thumbnails.Select(t => new MediaThumbnailDto
                {
                    Id = t.Id,
                    ThumbnailPath = t.FilePath,
                })
                .ToList(),
            Translations = media
                .Translations.Select(t => new MediaTranslationDto
                {
                    Id = t.Id,
                    Language = t.Language.Name,
                    Title = t.Type,
                })
                .ToList(),
        };
    }
}

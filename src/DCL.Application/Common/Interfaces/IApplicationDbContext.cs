using DCL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCL.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Media> Media { get; }
    DbSet<AdultDetail> AdultDetails { get; }
    DbSet<MovieDetail> MovieDetails { get; }
    DbSet<SeriesDetail> SeriesDetails { get; }
    DbSet<MusicDetail> MusicDetails { get; }
    DbSet<GameDetail> GameDetails { get; }
    DbSet<MediaGenre> MediaGenres { get; }
    DbSet<MediaTag> MediaTags { get; }
    DbSet<MediaType> MediaTypes { get; }
    DbSet<AgeRating> AgeRatings { get; }
    DbSet<Genre> Genres { get; }
    DbSet<Tag> Tags { get; }
    DbSet<Quality> Qualities { get; }
    DbSet<FileFormat> FileFormats { get; }
    DbSet<StorageDevice> StorageDevices { get; }
    DbSet<Language> Languages { get; }
    DbSet<FrameRateMode> FrameRateModes { get; }
    DbSet<ScanType> ScanTypes { get; }
    DbSet<MediaFile> MediaFiles { get; }
    DbSet<VideoFileDetail> VideoFileDetails { get; }
    DbSet<ImageFileDetail> ImageFileDetails { get; }
    DbSet<Actor> Actors { get; }
    DbSet<ActorTag> ActorTags { get; }
    DbSet<MediaActor> MediaActors { get; }
    DbSet<IsAdult> IsAdults { get; }
    DbSet<Country> Countries { get; }
    DbSet<Gender> Genders { get; }
    DbSet<MediaCountry> MediaCountries { get; }

    // DbSet<Director> Directors { get; }
    DbSet<Maker> Makers { get; }
    DbSet<Label> Labels { get; }
    DbSet<DownloadSource> DownloadSources { get; }
    DbSet<SourceType> SourceTypes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

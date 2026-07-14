using DCL.Application.Common.Interfaces;
using DCL.Domain.Entities;
using DCL.Domain.Entities.Lkp;
using Microsoft.EntityFrameworkCore;

namespace DCL.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // Core
    public DbSet<Media> Media => Set<Media>();
    public DbSet<MediaFile> MediaFiles => Set<MediaFile>();
    public DbSet<MediaThumbnail> MediaThumbnails => Set<MediaThumbnail>();
    public DbSet<MediaTranslation> MediaTranslations => Set<MediaTranslation>();
    public DbSet<MediaActor> MediaActors => Set<MediaActor>();
    public DbSet<MediaCountry> MediaCountries => Set<MediaCountry>();
    public DbSet<ActorTag> ActorTags => Set<ActorTag>();

    // Junction
    public DbSet<MediaGenre> MediaGenres => Set<MediaGenre>();
    public DbSet<MediaTag> MediaTags => Set<MediaTag>();

    // LKP
    public DbSet<MediaType> MediaTypes => Set<MediaType>();
    public DbSet<AgeRating> AgeRatings => Set<AgeRating>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Quality> Qualities => Set<Quality>();
    public DbSet<FileFormat> FileFormats => Set<FileFormat>();
    public DbSet<StorageDevice> StorageDevices => Set<StorageDevice>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<FrameRateMode> FrameRateModes => Set<FrameRateMode>();
    public DbSet<ScanType> ScanTypes => Set<ScanType>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Maker> Makers => Set<Maker>();
    public DbSet<Label> Labels => Set<Label>();
    public DbSet<DownloadSource> DownloadSources => Set<DownloadSource>();
    public DbSet<SourceType> SourceTypes => Set<SourceType>();
    public DbSet<AdultDetail> AdultDetails { get; set; }
    public DbSet<MovieDetail> MovieDetails { get; set; }
    public DbSet<SeriesDetail> SeriesDetails { get; set; }
    public DbSet<MusicDetail> MusicDetails { get; set; }
    public DbSet<GameDetail> GameDetails { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<IsAdult> IsAdults { get; set; }

    public DbSet<VideoFileDetail> VideoFileDetails => Set<VideoFileDetail>();
    public DbSet<ImageFileDetail> ImageFileDetails => Set<ImageFileDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Junction tables composite keys
        modelBuilder.Entity<MediaGenre>().HasKey(x => new { x.MediaId, x.GenreId });

        modelBuilder.Entity<MediaTag>().HasKey(x => new { x.MediaId, x.TagId });

        // LKP table names
        modelBuilder.Entity<MediaType>().ToTable("lkp_media_type");
        modelBuilder.Entity<AgeRating>().ToTable("lkp_age_rating");
        modelBuilder.Entity<Genre>().ToTable("lkp_genre");
        modelBuilder.Entity<Tag>().ToTable("lkp_tag");
        modelBuilder.Entity<Quality>().ToTable("lkp_quality");
        modelBuilder.Entity<FileFormat>().ToTable("lkp_file_format");
        modelBuilder.Entity<StorageDevice>().ToTable("lkp_storage_device");
        modelBuilder.Entity<Language>().ToTable("lkp_language");
        modelBuilder.Entity<FrameRateMode>().ToTable("lkp_frame_rate_mode");
        modelBuilder.Entity<ScanType>().ToTable("lkp_scan_type");
        modelBuilder.Entity<Actor>().ToTable("lkp_actor");
        modelBuilder.Entity<Director>().ToTable("lkp_director");
        modelBuilder.Entity<Maker>().ToTable("lkp_maker");
        modelBuilder.Entity<Label>().ToTable("lkp_label");
        modelBuilder.Entity<Country>().ToTable("lkp_Country");
        modelBuilder.Entity<Gender>().ToTable("lkp_Gender");
        modelBuilder.Entity<IsAdult>().ToTable("lkp_IsAdult");
        modelBuilder.Entity<DownloadSource>().ToTable("lkp_download_source");
        modelBuilder.Entity<SourceType>().ToTable("lkp_source_type");
        modelBuilder.Entity<MediaActor>().HasKey(x => new { x.MediaId, x.ActorId });
        modelBuilder.Entity<MediaCountry>().HasKey(x => new { x.MediaId, x.CountryId });
        modelBuilder.Entity<MediaActor>().ToTable("media_actor");
        modelBuilder.Entity<ActorTag>().HasKey(x => new { x.ActorId, x.TagId });
        modelBuilder.Entity<Actor>().ToTable("actor");

        // Seed MediaType
        modelBuilder
            .Entity<MediaType>()
            .HasData(
                new MediaType { Id = 1, Name = "Movie" },
                new MediaType { Id = 2, Name = "Series" },
                new MediaType { Id = 3, Name = "Music" },
                new MediaType { Id = 4, Name = "Game" },
                new MediaType { Id = 5, Name = "Image" },
                new MediaType { Id = 6, Name = "Adult" }
            );

        modelBuilder
            .Entity<VideoFileDetail>()
            .HasOne(v => v.MediaFile)
            .WithOne(f => f.VideoDetail)
            .HasForeignKey<VideoFileDetail>(v => v.MediaFileId);

        modelBuilder
            .Entity<ImageFileDetail>()
            .HasOne(i => i.MediaFile)
            .WithOne(f => f.ImageDetail)
            .HasForeignKey<ImageFileDetail>(i => i.MediaFileId);

        // Seed AgeRating
        modelBuilder
            .Entity<AgeRating>()
            .HasData(
                new AgeRating
                {
                    Id = 1,
                    Name = "G",
                    MinAge = 0,
                },
                new AgeRating
                {
                    Id = 2,
                    Name = "PG",
                    MinAge = 10,
                },
                new AgeRating
                {
                    Id = 3,
                    Name = "PG-13",
                    MinAge = 13,
                },
                new AgeRating
                {
                    Id = 4,
                    Name = "R",
                    MinAge = 17,
                },
                new AgeRating
                {
                    Id = 5,
                    Name = "NC-17",
                    MinAge = 18,
                },
                new AgeRating
                {
                    Id = 6,
                    Name = "XXX",
                    MinAge = 18,
                }
            );
        // FileFormat
        modelBuilder
            .Entity<FileFormat>()
            .HasData(
                new FileFormat { Id = 1, Name = "MP4" },
                new FileFormat { Id = 2, Name = "MKV" },
                new FileFormat { Id = 3, Name = "AVI" },
                new FileFormat { Id = 4, Name = "MOV" },
                new FileFormat { Id = 5, Name = "WMV" },
                new FileFormat { Id = 6, Name = "FLAC" },
                new FileFormat { Id = 7, Name = "MP3" },
                new FileFormat { Id = 8, Name = "ISO" }
            );
        // FrameRateMode
        modelBuilder
            .Entity<FrameRateMode>()
            .HasData(
                new FrameRateMode { Id = 1, Name = "CFR" },
                new FrameRateMode { Id = 2, Name = "VFR" }
            );
        // ScanType
        modelBuilder
            .Entity<ScanType>()
            .HasData(
                new ScanType { Id = 1, Name = "Progressive" },
                new ScanType { Id = 2, Name = "Interlaced" }
            );
        // Quality
        modelBuilder
            .Entity<Quality>()
            .HasData(
                new Quality
                {
                    Id = 1,
                    Name = "480p",
                    ResolutionW = 854,
                    ResolutionH = 480,
                },
                new Quality
                {
                    Id = 2,
                    Name = "720p",
                    ResolutionW = 1280,
                    ResolutionH = 720,
                },
                new Quality
                {
                    Id = 3,
                    Name = "1080p",
                    ResolutionW = 1920,
                    ResolutionH = 1080,
                },
                new Quality
                {
                    Id = 4,
                    Name = "1440p",
                    ResolutionW = 2560,
                    ResolutionH = 1440,
                },
                new Quality
                {
                    Id = 5,
                    Name = "4K",
                    ResolutionW = 3840,
                    ResolutionH = 2160,
                }
            );
        // SourceType
        modelBuilder
            .Entity<SourceType>()
            .HasData(
                new SourceType { Id = 1, Name = "Torrent" },
                new SourceType { Id = 2, Name = "Direct Download" },
                new SourceType { Id = 3, Name = "Usenet" },
                new SourceType { Id = 4, Name = "Physical" }
            );
        // Language (common ones)
        modelBuilder
            .Entity<Language>()
            .HasData(
                new Language
                {
                    Id = 1,
                    Name = "English",
                    Code = "en",
                },
                new Language
                {
                    Id = 2,
                    Name = "Arabic",
                    Code = "ar",
                },
                new Language
                {
                    Id = 3,
                    Name = "Japanese",
                    Code = "ja",
                },
                new Language
                {
                    Id = 4,
                    Name = "French",
                    Code = "fr",
                },
                new Language
                {
                    Id = 5,
                    Name = "Spanish",
                    Code = "es",
                },
                new Language
                {
                    Id = 6,
                    Name = "German",
                    Code = "de",
                }
            );
    }
}

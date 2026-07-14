using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdultDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_actor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_age_rating",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MinAge = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_age_rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_director",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_director", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_file_format",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_file_format", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_frame_rate_mode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_frame_rate_mode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_genre",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_label",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_language",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_maker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_maker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_media_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_media_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_quality",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ResolutionW = table.Column<int>(type: "INTEGER", nullable: true),
                    ResolutionH = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_quality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_scan_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_scan_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_source_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_source_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_storage_device",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MountPath = table.Column<string>(type: "TEXT", nullable: true),
                    TotalSpaceGb = table.Column<double>(type: "REAL", nullable: true),
                    FreeSpaceGb = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_storage_device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_tag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkp_download_source",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SourceTypeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_download_source", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lkp_download_source_lkp_source_type_SourceTypeId",
                        column: x => x.SourceTypeId,
                        principalTable: "lkp_source_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    MediaTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    AgeRatingId = table.Column<long>(type: "INTEGER", nullable: true),
                    IsAdultContent = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: true),
                    Rating = table.Column<float>(type: "REAL", nullable: true),
                    CoverImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsWatched = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    AdultDetailId = table.Column<long>(type: "INTEGER", nullable: true),
                    MovieDetailId = table.Column<long>(type: "INTEGER", nullable: true),
                    SeriesDetailId = table.Column<long>(type: "INTEGER", nullable: true),
                    MusicDetailId = table.Column<long>(type: "INTEGER", nullable: true),
                    GameDetailId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_AdultDetail_AdultDetailId",
                        column: x => x.AdultDetailId,
                        principalTable: "AdultDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_GameDetail_GameDetailId",
                        column: x => x.GameDetailId,
                        principalTable: "GameDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_MovieDetail_MovieDetailId",
                        column: x => x.MovieDetailId,
                        principalTable: "MovieDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_MusicDetail_MusicDetailId",
                        column: x => x.MusicDetailId,
                        principalTable: "MusicDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_SeriesDetail_SeriesDetailId",
                        column: x => x.SeriesDetailId,
                        principalTable: "SeriesDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_lkp_age_rating_AgeRatingId",
                        column: x => x.AgeRatingId,
                        principalTable: "lkp_age_rating",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Media_lkp_media_type_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "lkp_media_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaId = table.Column<long>(type: "INTEGER", nullable: false),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    FileFormatId = table.Column<long>(type: "INTEGER", nullable: false),
                    QualityId = table.Column<long>(type: "INTEGER", nullable: true),
                    ScanTypeId = table.Column<long>(type: "INTEGER", nullable: true),
                    FrameRateModeId = table.Column<long>(type: "INTEGER", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: true),
                    BitRate = table.Column<double>(type: "REAL", nullable: false),
                    ReferenceFrame = table.Column<int>(type: "INTEGER", nullable: false),
                    FrameRate = table.Column<double>(type: "REAL", nullable: false),
                    BitsPerPixelFrame = table.Column<double>(type: "REAL", nullable: false),
                    BitDepth = table.Column<double>(type: "REAL", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_MediaFiles_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaFiles_lkp_file_format_FileFormatId",
                        column: x => x.FileFormatId,
                        principalTable: "lkp_file_format",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaFiles_lkp_frame_rate_mode_FrameRateModeId",
                        column: x => x.FrameRateModeId,
                        principalTable: "lkp_frame_rate_mode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaFiles_lkp_quality_QualityId",
                        column: x => x.QualityId,
                        principalTable: "lkp_quality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaFiles_lkp_scan_type_ScanTypeId",
                        column: x => x.ScanTypeId,
                        principalTable: "lkp_scan_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaFiles_lkp_storage_device_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "lkp_storage_device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaGenres",
                columns: table => new
                {
                    MediaId = table.Column<long>(type: "INTEGER", nullable: false),
                    GenreId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGenres", x => new { x.MediaId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MediaGenres_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaGenres_lkp_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "lkp_genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaTags",
                columns: table => new
                {
                    MediaId = table.Column<long>(type: "INTEGER", nullable: false),
                    TagId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTags", x => new { x.MediaId, x.TagId });
                    table.ForeignKey(
                        name: "FK_MediaTags_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaTags_lkp_tag_TagId",
                        column: x => x.TagId,
                        principalTable: "lkp_tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaThumbnails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaId = table.Column<long>(type: "INTEGER", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaThumbnails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaThumbnails_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaThumbnails_lkp_storage_device_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "lkp_storage_device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaId = table.Column<long>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<long>(type: "INTEGER", nullable: false),
                    StorageDeviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaTranslations_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaTranslations_lkp_language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "lkp_language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaTranslations_lkp_storage_device_StorageDeviceId",
                        column: x => x.StorageDeviceId,
                        principalTable: "lkp_storage_device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lkp_download_source_SourceTypeId",
                table: "lkp_download_source",
                column: "SourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_AdultDetailId",
                table: "Media",
                column: "AdultDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_AgeRatingId",
                table: "Media",
                column: "AgeRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_GameDetailId",
                table: "Media",
                column: "GameDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaTypeId",
                table: "Media",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MovieDetailId",
                table: "Media",
                column: "MovieDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MusicDetailId",
                table: "Media",
                column: "MusicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_SeriesDetailId",
                table: "Media",
                column: "SeriesDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_FileFormatId",
                table: "MediaFiles",
                column: "FileFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_FrameRateModeId",
                table: "MediaFiles",
                column: "FrameRateModeId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_MediaId",
                table: "MediaFiles",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_QualityId",
                table: "MediaFiles",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ScanTypeId",
                table: "MediaFiles",
                column: "ScanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_StorageDeviceId",
                table: "MediaFiles",
                column: "StorageDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenres_GenreId",
                table: "MediaGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTags_TagId",
                table: "MediaTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaThumbnails_MediaId",
                table: "MediaThumbnails",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaThumbnails_StorageDeviceId",
                table: "MediaThumbnails",
                column: "StorageDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTranslations_LanguageId",
                table: "MediaTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTranslations_MediaId",
                table: "MediaTranslations",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTranslations_StorageDeviceId",
                table: "MediaTranslations",
                column: "StorageDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lkp_actor");

            migrationBuilder.DropTable(
                name: "lkp_director");

            migrationBuilder.DropTable(
                name: "lkp_download_source");

            migrationBuilder.DropTable(
                name: "lkp_label");

            migrationBuilder.DropTable(
                name: "lkp_maker");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "MediaGenres");

            migrationBuilder.DropTable(
                name: "MediaTags");

            migrationBuilder.DropTable(
                name: "MediaThumbnails");

            migrationBuilder.DropTable(
                name: "MediaTranslations");

            migrationBuilder.DropTable(
                name: "lkp_source_type");

            migrationBuilder.DropTable(
                name: "lkp_file_format");

            migrationBuilder.DropTable(
                name: "lkp_frame_rate_mode");

            migrationBuilder.DropTable(
                name: "lkp_quality");

            migrationBuilder.DropTable(
                name: "lkp_scan_type");

            migrationBuilder.DropTable(
                name: "lkp_genre");

            migrationBuilder.DropTable(
                name: "lkp_tag");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "lkp_language");

            migrationBuilder.DropTable(
                name: "lkp_storage_device");

            migrationBuilder.DropTable(
                name: "AdultDetail");

            migrationBuilder.DropTable(
                name: "GameDetail");

            migrationBuilder.DropTable(
                name: "MovieDetail");

            migrationBuilder.DropTable(
                name: "MusicDetail");

            migrationBuilder.DropTable(
                name: "SeriesDetail");

            migrationBuilder.DropTable(
                name: "lkp_age_rating");

            migrationBuilder.DropTable(
                name: "lkp_media_type");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedLkpData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "lkp_age_rating",
                columns: new[] { "Id", "MinAge", "Name" },
                values: new object[,]
                {
                    { 1L, 0, "G" },
                    { 2L, 10, "PG" },
                    { 3L, 13, "PG-13" },
                    { 4L, 17, "R" },
                    { 5L, 18, "NC-17" },
                    { 6L, 18, "XXX" }
                });

            migrationBuilder.InsertData(
                table: "lkp_file_format",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "MP4" },
                    { 2L, "MKV" },
                    { 3L, "AVI" },
                    { 4L, "MOV" },
                    { 5L, "WMV" },
                    { 6L, "FLAC" },
                    { 7L, "MP3" },
                    { 8L, "ISO" }
                });

            migrationBuilder.InsertData(
                table: "lkp_frame_rate_mode",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "CFR" },
                    { 2L, "VFR" }
                });

            migrationBuilder.InsertData(
                table: "lkp_language",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1L, "en", "English" },
                    { 2L, "ar", "Arabic" },
                    { 3L, "ja", "Japanese" },
                    { 4L, "fr", "French" },
                    { 5L, "es", "Spanish" },
                    { 6L, "de", "German" }
                });

            migrationBuilder.InsertData(
                table: "lkp_media_type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Movie" },
                    { 2L, "Series" },
                    { 3L, "Music" },
                    { 4L, "Game" },
                    { 5L, "Image" },
                    { 6L, "Adult" }
                });

            migrationBuilder.InsertData(
                table: "lkp_quality",
                columns: new[] { "Id", "Name", "ResolutionH", "ResolutionW" },
                values: new object[,]
                {
                    { 1L, "480p", 480, 854 },
                    { 2L, "720p", 720, 1280 },
                    { 3L, "1080p", 1080, 1920 },
                    { 4L, "1440p", 1440, 2560 },
                    { 5L, "4K", 2160, 3840 }
                });

            migrationBuilder.InsertData(
                table: "lkp_scan_type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Progressive" },
                    { 2L, "Interlaced" }
                });

            migrationBuilder.InsertData(
                table: "lkp_source_type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Torrent" },
                    { 2L, "Direct Download" },
                    { 3L, "Usenet" },
                    { 4L, "Physical" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "lkp_age_rating",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_age_rating",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_age_rating",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "lkp_age_rating",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "lkp_age_rating",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "lkp_age_rating",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "lkp_file_format",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "lkp_frame_rate_mode",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_frame_rate_mode",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_language",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_language",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_language",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "lkp_language",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "lkp_language",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "lkp_language",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "lkp_media_type",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_media_type",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_media_type",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "lkp_media_type",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "lkp_media_type",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "lkp_media_type",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "lkp_quality",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_quality",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_quality",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "lkp_quality",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "lkp_quality",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "lkp_scan_type",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_scan_type",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_source_type",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "lkp_source_type",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "lkp_source_type",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "lkp_source_type",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}

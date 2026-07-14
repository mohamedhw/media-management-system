using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateforthemediacopy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_lkp_frame_rate_mode_FrameRateModeId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_lkp_quality_QualityId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_lkp_scan_type_ScanTypeId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_FrameRateModeId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_QualityId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_ScanTypeId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "BitDepth",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "BitRate",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "BitsPerPixelFrame",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "FrameRate",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "FrameRateModeId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "QualityId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "ReferenceFrame",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "ScanTypeId",
                table: "MediaFiles");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "MediaFiles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MediaFiles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageFileDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaFileId = table.Column<long>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    BitDepth = table.Column<double>(type: "REAL", nullable: true),
                    ColorSpace = table.Column<string>(type: "TEXT", nullable: true),
                    HasAlpha = table.Column<bool>(type: "INTEGER", nullable: false),
                    CameraModel = table.Column<string>(type: "TEXT", nullable: true),
                    DateTaken = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFileDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFileDetail_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoFileDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaFileId = table.Column<long>(type: "INTEGER", nullable: false),
                    QualityId = table.Column<long>(type: "INTEGER", nullable: true),
                    ScanTypeId = table.Column<long>(type: "INTEGER", nullable: true),
                    FrameRateModeId = table.Column<long>(type: "INTEGER", nullable: true),
                    BitRate = table.Column<double>(type: "REAL", nullable: false),
                    FrameRate = table.Column<double>(type: "REAL", nullable: false),
                    BitsPerPixelFrame = table.Column<double>(type: "REAL", nullable: false),
                    BitDepth = table.Column<double>(type: "REAL", nullable: false),
                    ReferenceFrame = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoFileDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoFileDetail_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoFileDetail_lkp_frame_rate_mode_FrameRateModeId",
                        column: x => x.FrameRateModeId,
                        principalTable: "lkp_frame_rate_mode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoFileDetail_lkp_quality_QualityId",
                        column: x => x.QualityId,
                        principalTable: "lkp_quality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoFileDetail_lkp_scan_type_ScanTypeId",
                        column: x => x.ScanTypeId,
                        principalTable: "lkp_scan_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageFileDetail_MediaFileId",
                table: "ImageFileDetail",
                column: "MediaFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoFileDetail_FrameRateModeId",
                table: "VideoFileDetail",
                column: "FrameRateModeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoFileDetail_MediaFileId",
                table: "VideoFileDetail",
                column: "MediaFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoFileDetail_QualityId",
                table: "VideoFileDetail",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoFileDetail_ScanTypeId",
                table: "VideoFileDetail",
                column: "ScanTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageFileDetail");

            migrationBuilder.DropTable(
                name: "VideoFileDetail");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MediaFiles");

            migrationBuilder.AddColumn<double>(
                name: "BitDepth",
                table: "MediaFiles",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BitRate",
                table: "MediaFiles",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BitsPerPixelFrame",
                table: "MediaFiles",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrameRate",
                table: "MediaFiles",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "FrameRateModeId",
                table: "MediaFiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "MediaFiles",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "QualityId",
                table: "MediaFiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceFrame",
                table: "MediaFiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ScanTypeId",
                table: "MediaFiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_FrameRateModeId",
                table: "MediaFiles",
                column: "FrameRateModeId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_QualityId",
                table: "MediaFiles",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ScanTypeId",
                table: "MediaFiles",
                column: "ScanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_lkp_frame_rate_mode_FrameRateModeId",
                table: "MediaFiles",
                column: "FrameRateModeId",
                principalTable: "lkp_frame_rate_mode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_lkp_quality_QualityId",
                table: "MediaFiles",
                column: "QualityId",
                principalTable: "lkp_quality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_lkp_scan_type_ScanTypeId",
                table: "MediaFiles",
                column: "ScanTypeId",
                principalTable: "lkp_scan_type",
                principalColumn: "Id");
        }
    }
}

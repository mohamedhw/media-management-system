using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateforthemediacopy2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFileDetail_MediaFiles_MediaFileId",
                table: "ImageFileDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetail_MediaFiles_MediaFileId",
                table: "VideoFileDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetail_lkp_frame_rate_mode_FrameRateModeId",
                table: "VideoFileDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetail_lkp_quality_QualityId",
                table: "VideoFileDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetail_lkp_scan_type_ScanTypeId",
                table: "VideoFileDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoFileDetail",
                table: "VideoFileDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFileDetail",
                table: "ImageFileDetail");

            migrationBuilder.RenameTable(
                name: "VideoFileDetail",
                newName: "VideoFileDetails");

            migrationBuilder.RenameTable(
                name: "ImageFileDetail",
                newName: "ImageFileDetails");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetail_ScanTypeId",
                table: "VideoFileDetails",
                newName: "IX_VideoFileDetails_ScanTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetail_QualityId",
                table: "VideoFileDetails",
                newName: "IX_VideoFileDetails_QualityId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetail_MediaFileId",
                table: "VideoFileDetails",
                newName: "IX_VideoFileDetails_MediaFileId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetail_FrameRateModeId",
                table: "VideoFileDetails",
                newName: "IX_VideoFileDetails_FrameRateModeId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageFileDetail_MediaFileId",
                table: "ImageFileDetails",
                newName: "IX_ImageFileDetails_MediaFileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoFileDetails",
                table: "VideoFileDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFileDetails",
                table: "ImageFileDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFileDetails_MediaFiles_MediaFileId",
                table: "ImageFileDetails",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetails_MediaFiles_MediaFileId",
                table: "VideoFileDetails",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetails_lkp_frame_rate_mode_FrameRateModeId",
                table: "VideoFileDetails",
                column: "FrameRateModeId",
                principalTable: "lkp_frame_rate_mode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetails_lkp_quality_QualityId",
                table: "VideoFileDetails",
                column: "QualityId",
                principalTable: "lkp_quality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetails_lkp_scan_type_ScanTypeId",
                table: "VideoFileDetails",
                column: "ScanTypeId",
                principalTable: "lkp_scan_type",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFileDetails_MediaFiles_MediaFileId",
                table: "ImageFileDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetails_MediaFiles_MediaFileId",
                table: "VideoFileDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetails_lkp_frame_rate_mode_FrameRateModeId",
                table: "VideoFileDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetails_lkp_quality_QualityId",
                table: "VideoFileDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoFileDetails_lkp_scan_type_ScanTypeId",
                table: "VideoFileDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoFileDetails",
                table: "VideoFileDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFileDetails",
                table: "ImageFileDetails");

            migrationBuilder.RenameTable(
                name: "VideoFileDetails",
                newName: "VideoFileDetail");

            migrationBuilder.RenameTable(
                name: "ImageFileDetails",
                newName: "ImageFileDetail");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetails_ScanTypeId",
                table: "VideoFileDetail",
                newName: "IX_VideoFileDetail_ScanTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetails_QualityId",
                table: "VideoFileDetail",
                newName: "IX_VideoFileDetail_QualityId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetails_MediaFileId",
                table: "VideoFileDetail",
                newName: "IX_VideoFileDetail_MediaFileId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoFileDetails_FrameRateModeId",
                table: "VideoFileDetail",
                newName: "IX_VideoFileDetail_FrameRateModeId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageFileDetails_MediaFileId",
                table: "ImageFileDetail",
                newName: "IX_ImageFileDetail_MediaFileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoFileDetail",
                table: "VideoFileDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFileDetail",
                table: "ImageFileDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFileDetail_MediaFiles_MediaFileId",
                table: "ImageFileDetail",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetail_MediaFiles_MediaFileId",
                table: "VideoFileDetail",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetail_lkp_frame_rate_mode_FrameRateModeId",
                table: "VideoFileDetail",
                column: "FrameRateModeId",
                principalTable: "lkp_frame_rate_mode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetail_lkp_quality_QualityId",
                table: "VideoFileDetail",
                column: "QualityId",
                principalTable: "lkp_quality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoFileDetail_lkp_scan_type_ScanTypeId",
                table: "VideoFileDetail",
                column: "ScanTypeId",
                principalTable: "lkp_scan_type",
                principalColumn: "Id");
        }
    }
}

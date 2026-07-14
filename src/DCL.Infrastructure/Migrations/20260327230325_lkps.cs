using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lkps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdultDetail_Media_MediaId",
                table: "AdultDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDetail_Media_MediaId",
                table: "GameDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDetail_Media_MediaId",
                table: "MovieDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicDetail_Media_MediaId",
                table: "MusicDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesDetail_Media_MediaId",
                table: "SeriesDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesDetail",
                table: "SeriesDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicDetail",
                table: "MusicDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDetail",
                table: "MovieDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDetail",
                table: "GameDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdultDetail",
                table: "AdultDetail");

            migrationBuilder.RenameTable(
                name: "SeriesDetail",
                newName: "SeriesDetails");

            migrationBuilder.RenameTable(
                name: "MusicDetail",
                newName: "MusicDetails");

            migrationBuilder.RenameTable(
                name: "MovieDetail",
                newName: "MovieDetails");

            migrationBuilder.RenameTable(
                name: "GameDetail",
                newName: "GameDetails");

            migrationBuilder.RenameTable(
                name: "AdultDetail",
                newName: "AdultDetails");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesDetail_MediaId",
                table: "SeriesDetails",
                newName: "IX_SeriesDetails_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicDetail_MediaId",
                table: "MusicDetails",
                newName: "IX_MusicDetails_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDetail_MediaId",
                table: "MovieDetails",
                newName: "IX_MovieDetails_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_GameDetail_MediaId",
                table: "GameDetails",
                newName: "IX_GameDetails_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_AdultDetail_MediaId",
                table: "AdultDetails",
                newName: "IX_AdultDetails_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesDetails",
                table: "SeriesDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicDetails",
                table: "MusicDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDetails",
                table: "MovieDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDetails",
                table: "GameDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdultDetails",
                table: "AdultDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultDetails_Media_MediaId",
                table: "AdultDetails",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDetails_Media_MediaId",
                table: "GameDetails",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDetails_Media_MediaId",
                table: "MovieDetails",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicDetails_Media_MediaId",
                table: "MusicDetails",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesDetails_Media_MediaId",
                table: "SeriesDetails",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdultDetails_Media_MediaId",
                table: "AdultDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDetails_Media_MediaId",
                table: "GameDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDetails_Media_MediaId",
                table: "MovieDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicDetails_Media_MediaId",
                table: "MusicDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesDetails_Media_MediaId",
                table: "SeriesDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesDetails",
                table: "SeriesDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicDetails",
                table: "MusicDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDetails",
                table: "MovieDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDetails",
                table: "GameDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdultDetails",
                table: "AdultDetails");

            migrationBuilder.RenameTable(
                name: "SeriesDetails",
                newName: "SeriesDetail");

            migrationBuilder.RenameTable(
                name: "MusicDetails",
                newName: "MusicDetail");

            migrationBuilder.RenameTable(
                name: "MovieDetails",
                newName: "MovieDetail");

            migrationBuilder.RenameTable(
                name: "GameDetails",
                newName: "GameDetail");

            migrationBuilder.RenameTable(
                name: "AdultDetails",
                newName: "AdultDetail");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesDetails_MediaId",
                table: "SeriesDetail",
                newName: "IX_SeriesDetail_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicDetails_MediaId",
                table: "MusicDetail",
                newName: "IX_MusicDetail_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDetails_MediaId",
                table: "MovieDetail",
                newName: "IX_MovieDetail_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_GameDetails_MediaId",
                table: "GameDetail",
                newName: "IX_GameDetail_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_AdultDetails_MediaId",
                table: "AdultDetail",
                newName: "IX_AdultDetail_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesDetail",
                table: "SeriesDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicDetail",
                table: "MusicDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDetail",
                table: "MovieDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDetail",
                table: "GameDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdultDetail",
                table: "AdultDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultDetail_Media_MediaId",
                table: "AdultDetail",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDetail_Media_MediaId",
                table: "GameDetail",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDetail_Media_MediaId",
                table: "MovieDetail",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicDetail_Media_MediaId",
                table: "MusicDetail",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesDetail_Media_MediaId",
                table: "SeriesDetail",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

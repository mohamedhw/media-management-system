using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_AdultDetail_AdultDetailId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GameDetail_GameDetailId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_MovieDetail_MovieDetailId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_MusicDetail_MusicDetailId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_SeriesDetail_SeriesDetailId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_AdultDetailId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_GameDetailId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_MovieDetailId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_MusicDetailId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_SeriesDetailId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MovieDetail");

            migrationBuilder.DropColumn(
                name: "AdultDetailId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "GameDetailId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MovieDetailId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MusicDetailId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "SeriesDetailId",
                table: "Media");

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "SeriesDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "MusicDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "MovieDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "MovieDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImdbId",
                table: "MovieDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "MovieDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Runtime",
                table: "MovieDetail",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "GameDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "AdultDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDetail_MediaId",
                table: "SeriesDetail",
                column: "MediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicDetail_MediaId",
                table: "MusicDetail",
                column: "MediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetail_MediaId",
                table: "MovieDetail",
                column: "MediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDetail_MediaId",
                table: "GameDetail",
                column: "MediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdultDetail_MediaId",
                table: "AdultDetail",
                column: "MediaId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_SeriesDetail_MediaId",
                table: "SeriesDetail");

            migrationBuilder.DropIndex(
                name: "IX_MusicDetail_MediaId",
                table: "MusicDetail");

            migrationBuilder.DropIndex(
                name: "IX_MovieDetail_MediaId",
                table: "MovieDetail");

            migrationBuilder.DropIndex(
                name: "IX_GameDetail_MediaId",
                table: "GameDetail");

            migrationBuilder.DropIndex(
                name: "IX_AdultDetail_MediaId",
                table: "AdultDetail");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "SeriesDetail");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MusicDetail");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "MovieDetail");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "MovieDetail");

            migrationBuilder.DropColumn(
                name: "ImdbId",
                table: "MovieDetail");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MovieDetail");

            migrationBuilder.DropColumn(
                name: "Runtime",
                table: "MovieDetail");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "GameDetail");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "AdultDetail");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MovieDetail",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "AdultDetailId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GameDetailId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MovieDetailId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MusicDetailId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SeriesDetailId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_AdultDetailId",
                table: "Media",
                column: "AdultDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_GameDetailId",
                table: "Media",
                column: "GameDetailId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Media_AdultDetail_AdultDetailId",
                table: "Media",
                column: "AdultDetailId",
                principalTable: "AdultDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_GameDetail_GameDetailId",
                table: "Media",
                column: "GameDetailId",
                principalTable: "GameDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MovieDetail_MovieDetailId",
                table: "Media",
                column: "MovieDetailId",
                principalTable: "MovieDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MusicDetail_MusicDetailId",
                table: "Media",
                column: "MusicDetailId",
                principalTable: "MusicDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_SeriesDetail_SeriesDetailId",
                table: "Media",
                column: "SeriesDetailId",
                principalTable: "SeriesDetail",
                principalColumn: "Id");
        }
    }
}

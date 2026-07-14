using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixlkps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lkp_Country_actor_ActorId",
                table: "lkp_Country");

            migrationBuilder.DropForeignKey(
                name: "FK_lkp_Gender_actor_ActorId",
                table: "lkp_Gender");

            migrationBuilder.DropForeignKey(
                name: "FK_lkp_IsAdult_Media_MediaId",
                table: "lkp_IsAdult");

            migrationBuilder.DropForeignKey(
                name: "FK_lkp_IsAdult_actor_ActorId",
                table: "lkp_IsAdult");

            migrationBuilder.DropIndex(
                name: "IX_lkp_IsAdult_ActorId",
                table: "lkp_IsAdult");

            migrationBuilder.DropIndex(
                name: "IX_lkp_IsAdult_MediaId",
                table: "lkp_IsAdult");

            migrationBuilder.DropIndex(
                name: "IX_lkp_Gender_ActorId",
                table: "lkp_Gender");

            migrationBuilder.DropIndex(
                name: "IX_lkp_Country_ActorId",
                table: "lkp_Country");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "lkp_IsAdult");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "lkp_IsAdult");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "lkp_Gender");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "lkp_Country");

            migrationBuilder.AddColumn<long>(
                name: "isAdultId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenderId1",
                table: "actor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "isAdultId",
                table: "actor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaCountries",
                columns: table => new
                {
                    MediaId = table.Column<long>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCountries", x => new { x.MediaId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_MediaCountries_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaCountries_lkp_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "lkp_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_isAdultId",
                table: "Media",
                column: "isAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_actor_CountryId",
                table: "actor",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_actor_GenderId1",
                table: "actor",
                column: "GenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_actor_isAdultId",
                table: "actor",
                column: "isAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCountries_CountryId",
                table: "MediaCountries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_actor_lkp_Country_CountryId",
                table: "actor",
                column: "CountryId",
                principalTable: "lkp_Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_actor_lkp_Gender_GenderId1",
                table: "actor",
                column: "GenderId1",
                principalTable: "lkp_Gender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_actor_lkp_IsAdult_isAdultId",
                table: "actor",
                column: "isAdultId",
                principalTable: "lkp_IsAdult",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_lkp_IsAdult_isAdultId",
                table: "Media",
                column: "isAdultId",
                principalTable: "lkp_IsAdult",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actor_lkp_Country_CountryId",
                table: "actor");

            migrationBuilder.DropForeignKey(
                name: "FK_actor_lkp_Gender_GenderId1",
                table: "actor");

            migrationBuilder.DropForeignKey(
                name: "FK_actor_lkp_IsAdult_isAdultId",
                table: "actor");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_lkp_IsAdult_isAdultId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "MediaCountries");

            migrationBuilder.DropIndex(
                name: "IX_Media_isAdultId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_actor_CountryId",
                table: "actor");

            migrationBuilder.DropIndex(
                name: "IX_actor_GenderId1",
                table: "actor");

            migrationBuilder.DropIndex(
                name: "IX_actor_isAdultId",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "isAdultId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "GenderId1",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "isAdultId",
                table: "actor");

            migrationBuilder.AddColumn<long>(
                name: "ActorId",
                table: "lkp_IsAdult",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "lkp_IsAdult",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ActorId",
                table: "lkp_Gender",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ActorId",
                table: "lkp_Country",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lkp_IsAdult_ActorId",
                table: "lkp_IsAdult",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_IsAdult_MediaId",
                table: "lkp_IsAdult",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Gender_ActorId",
                table: "lkp_Gender",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Country_ActorId",
                table: "lkp_Country",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_lkp_Country_actor_ActorId",
                table: "lkp_Country",
                column: "ActorId",
                principalTable: "actor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lkp_Gender_actor_ActorId",
                table: "lkp_Gender",
                column: "ActorId",
                principalTable: "actor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lkp_IsAdult_Media_MediaId",
                table: "lkp_IsAdult",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lkp_IsAdult_actor_ActorId",
                table: "lkp_IsAdult",
                column: "ActorId",
                principalTable: "actor",
                principalColumn: "Id");
        }
    }
}

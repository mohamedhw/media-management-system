using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedlkps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdultContent",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "actor",
                newName: "Website");

            migrationBuilder.AddColumn<int>(
                name: "IsAdultsId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "actor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "actor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instgram",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsAdultsId",
                table: "actor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Riddet",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twiter",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lkp_Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ActorId = table.Column<long>(type: "INTEGER", nullable: true),
                    MediaId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lkp_Country_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lkp_Country_actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lkp_Gender",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ActorId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_Gender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lkp_Gender_actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lkp_IsAdult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ActorId = table.Column<long>(type: "INTEGER", nullable: true),
                    MediaId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkp_IsAdult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lkp_IsAdult_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lkp_IsAdult_actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Country_ActorId",
                table: "lkp_Country",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Country_MediaId",
                table: "lkp_Country",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Gender_ActorId",
                table: "lkp_Gender",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_IsAdult_ActorId",
                table: "lkp_IsAdult",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_lkp_IsAdult_MediaId",
                table: "lkp_IsAdult",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lkp_Country");

            migrationBuilder.DropTable(
                name: "lkp_Gender");

            migrationBuilder.DropTable(
                name: "lkp_IsAdult");

            migrationBuilder.DropColumn(
                name: "IsAdultsId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Instgram",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "IsAdultsId",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Riddet",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Twiter",
                table: "actor");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "actor",
                newName: "Country");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdultContent",
                table: "Media",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}

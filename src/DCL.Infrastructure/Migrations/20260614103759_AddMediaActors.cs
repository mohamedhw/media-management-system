using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaActors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "media_actor",
                columns: table => new
                {
                    MediaId = table.Column<long>(type: "INTEGER", nullable: false),
                    ActorId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_actor", x => new { x.MediaId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_media_actor_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_media_actor_lkp_actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "lkp_actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_media_actor_ActorId",
                table: "media_actor",
                column: "ActorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "media_actor");
        }
    }
}

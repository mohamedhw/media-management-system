using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixlkps2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lkp_Country_Media_MediaId",
                table: "lkp_Country");

            migrationBuilder.DropIndex(
                name: "IX_lkp_Country_MediaId",
                table: "lkp_Country");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "lkp_Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "lkp_Country",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lkp_Country_MediaId",
                table: "lkp_Country",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_lkp_Country_Media_MediaId",
                table: "lkp_Country",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");
        }
    }
}

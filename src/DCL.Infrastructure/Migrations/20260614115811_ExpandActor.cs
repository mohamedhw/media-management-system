using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExpandActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_actor_lkp_actor_ActorId",
                table: "media_actor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lkp_actor",
                table: "lkp_actor");

            migrationBuilder.RenameTable(
                name: "lkp_actor",
                newName: "actor");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreastSize",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CupSize",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HipsSize",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Measurements",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaistSize",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "actor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_actor",
                table: "actor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActorTags",
                columns: table => new
                {
                    ActorId = table.Column<long>(type: "INTEGER", nullable: false),
                    TagId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorTags", x => new { x.ActorId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ActorTags_actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorTags_lkp_tag_TagId",
                        column: x => x.TagId,
                        principalTable: "lkp_tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorTags_TagId",
                table: "ActorTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_media_actor_actor_ActorId",
                table: "media_actor",
                column: "ActorId",
                principalTable: "actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_actor_actor_ActorId",
                table: "media_actor");

            migrationBuilder.DropTable(
                name: "ActorTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actor",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "BreastSize",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "CupSize",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "HipsSize",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Measurements",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "WaistSize",
                table: "actor");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "actor");

            migrationBuilder.RenameTable(
                name: "actor",
                newName: "lkp_actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lkp_actor",
                table: "lkp_actor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_media_actor_lkp_actor_ActorId",
                table: "media_actor",
                column: "ActorId",
                principalTable: "lkp_actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateforthemediacopy1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CameraModel",
                table: "ImageFileDetail");

            migrationBuilder.DropColumn(
                name: "DateTaken",
                table: "ImageFileDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CameraModel",
                table: "ImageFileDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTaken",
                table: "ImageFileDetail",
                type: "TEXT",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testni_zadatak.Migrations
{
    public partial class Updatereference13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "modified",
                table: "GmlCoordinates",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "modified",
                table: "GmlCoordinateModel",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modified",
                table: "GmlCoordinates");

            migrationBuilder.DropColumn(
                name: "modified",
                table: "GmlCoordinateModel");
        }
    }
}

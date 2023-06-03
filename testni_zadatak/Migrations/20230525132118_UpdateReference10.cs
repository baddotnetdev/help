using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testni_zadatak.Migrations
{
    public partial class UpdateReference10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GmlCoordinates_GmlFeatureId",
                table: "GmlCoordinates");

            migrationBuilder.AlterColumn<double>(
                name: "Y",
                table: "GmlCoordinates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double[]),
                oldType: "double precision[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "X",
                table: "GmlCoordinates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double[]),
                oldType: "double precision[]",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GmlCoordinates_GmlFeatureId",
                table: "GmlCoordinates",
                column: "GmlFeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GmlCoordinates_GmlFeatureId",
                table: "GmlCoordinates");

            migrationBuilder.AlterColumn<double[]>(
                name: "Y",
                table: "GmlCoordinates",
                type: "double precision[]",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double[]>(
                name: "X",
                table: "GmlCoordinates",
                type: "double precision[]",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateIndex(
                name: "IX_GmlCoordinates_GmlFeatureId",
                table: "GmlCoordinates",
                column: "GmlFeatureId",
                unique: true);
        }
    }
}

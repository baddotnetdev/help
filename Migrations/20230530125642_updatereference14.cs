using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testni_zadatak.Migrations
{
    public partial class updatereference14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GmlCoordinateModel_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinateModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "GmlCoordinates",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<double>(
                name: "Y",
                table: "GmlCoordinates",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "X",
                table: "GmlCoordinates",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "GmlFeatureId",
                table: "GmlCoordinates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "GmlCoordinateModel",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<double>(
                name: "Y",
                table: "GmlCoordinateModel",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "X",
                table: "GmlCoordinateModel",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "GmlFeatureId",
                table: "GmlCoordinateModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_GmlCoordinateModel_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinateModel",
                column: "GmlFeatureId",
                principalTable: "GmlFeatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinates",
                column: "GmlFeatureId",
                principalTable: "GmlFeatures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GmlCoordinateModel_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinateModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "GmlCoordinates",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Y",
                table: "GmlCoordinates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "X",
                table: "GmlCoordinates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GmlFeatureId",
                table: "GmlCoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "GmlCoordinateModel",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Y",
                table: "GmlCoordinateModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "X",
                table: "GmlCoordinateModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GmlFeatureId",
                table: "GmlCoordinateModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GmlCoordinateModel_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinateModel",
                column: "GmlFeatureId",
                principalTable: "GmlFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinates",
                column: "GmlFeatureId",
                principalTable: "GmlFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

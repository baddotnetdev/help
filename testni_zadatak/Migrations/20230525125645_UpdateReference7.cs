using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testni_zadatak.Migrations
{
    public partial class UpdateReference7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double[]>(
                name: "Y",
                table: "GmlCoordinates",
                type: "double precision[]",
                nullable: true,
                oldClrType: typeof(double[]),
                oldType: "double precision[]",
                oldNullable: true,
                oldDefaultValue: new double[] { }
            );

            migrationBuilder.AlterColumn<double[]>(
                name: "X",
                table: "GmlCoordinates",
                type: "double precision[]",
                nullable: true,
                oldClrType: typeof(double[]),
                oldType: "double precision[]",
                oldNullable: true,
                oldDefaultValue: new double[] { }
            ); ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace testni_zadatak.Migrations
{
    public partial class UpdateReference3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId",
                table: "GmlCoordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GmlCoordinates",
                table: "GmlCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_GmlCoordinates_GmlFeatureId",
                table: "GmlCoordinates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GmlCoordinates");

            migrationBuilder.AlterColumn<int>(
                name: "GmlFeatureId",
                table: "GmlCoordinates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "GmlFeatureId1",
                table: "GmlCoordinates",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GmlCoordinates",
                table: "GmlCoordinates",
                column: "GmlFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_GmlCoordinates_GmlFeatureId1",
                table: "GmlCoordinates",
                column: "GmlFeatureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId1",
                table: "GmlCoordinates",
                column: "GmlFeatureId1",
                principalTable: "GmlFeatures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId1",
                table: "GmlCoordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GmlCoordinates",
                table: "GmlCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_GmlCoordinates_GmlFeatureId1",
                table: "GmlCoordinates");

            migrationBuilder.DropColumn(
                name: "GmlFeatureId1",
                table: "GmlCoordinates");

            migrationBuilder.AlterColumn<int>(
                name: "GmlFeatureId",
                table: "GmlCoordinates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GmlCoordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GmlCoordinates",
                table: "GmlCoordinates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GmlCoordinates_GmlFeatureId",
                table: "GmlCoordinates",
                column: "GmlFeatureId");

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

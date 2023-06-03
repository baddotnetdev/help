using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testni_zadatak.Migrations
{
    public partial class UpdateReference11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId1",
                table: "GmlCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_GmlCoordinates_GmlFeatureId1",
                table: "GmlCoordinates");

            migrationBuilder.DropColumn(
                name: "GmlFeatureId1",
                table: "GmlCoordinates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GmlFeatureId1",
                table: "GmlCoordinates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GmlCoordinates_GmlFeatureId1",
                table: "GmlCoordinates",
                column: "GmlFeatureId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GmlCoordinates_GmlFeatures_GmlFeatureId1",
                table: "GmlCoordinates",
                column: "GmlFeatureId1",
                principalTable: "GmlFeatures",
                principalColumn: "Id");
        }
    }
}

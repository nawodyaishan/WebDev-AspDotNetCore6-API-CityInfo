using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfoServiceAPI.Migrations
{
    public partial class CityInfoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "PointsOfInterests",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "PointsOfInterests");
        }
    }
}

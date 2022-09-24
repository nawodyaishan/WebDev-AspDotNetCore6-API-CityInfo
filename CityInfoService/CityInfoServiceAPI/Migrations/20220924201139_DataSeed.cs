using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfoServiceAPI.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 1, "h9ew ud uewq dui phudwu9e dhu9wpe p", "Colombo" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 2, "h9ew ud uewq dui phudwu9e dhu9wpe p", "Badulla" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 3, "h9ew ud uewq dui phudwu9e dhu9wpe p", "Matara" });

            migrationBuilder.InsertData(
                table: "PointsOfInterests",
                columns: new[] { "id", "CityId", "description", "name" },
                values: new object[] { 1, 1, "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh", "Lotus Tower" });

            migrationBuilder.InsertData(
                table: "PointsOfInterests",
                columns: new[] { "id", "CityId", "description", "name" },
                values: new object[] { 2, 2, "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh", "Lotus Tower" });

            migrationBuilder.InsertData(
                table: "PointsOfInterests",
                columns: new[] { "id", "CityId", "description", "name" },
                values: new object[] { 3, 3, "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh", "Lotus Tower" });

            migrationBuilder.InsertData(
                table: "PointsOfInterests",
                columns: new[] { "id", "CityId", "description", "name" },
                values: new object[] { 4, 2, "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh", "Lotus Tower" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterests",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterests",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterests",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterests",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}

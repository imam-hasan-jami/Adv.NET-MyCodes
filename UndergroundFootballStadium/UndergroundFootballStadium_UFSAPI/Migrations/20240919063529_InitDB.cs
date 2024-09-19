using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UndergroundFootballStadium_UFSAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UFSs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFSs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UFSs",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Football", new DateTime(2024, 9, 19, 12, 35, 29, 156, DateTimeKind.Local).AddTicks(1397), "Mirpur UFS is a football stadium located in Mirpur, Dhaka, Bangladesh. It is the home of the Bangladesh national football team and Abahani Limited Dhaka. The stadium goes by the nickname 'The Cauldron'.", "", "Kings Arena", 10, 5000.0, 10000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Football", new DateTime(2024, 9, 19, 12, 35, 29, 156, DateTimeKind.Local).AddTicks(1411), "Old Trafford is a football stadium in Old Trafford, Greater Manchester, England, and the home of Manchester United. With a capacity of 74,140 seats, it is the largest club football stadium in the United Kingdom, and the eleventh-largest in Europe.", "", "Old Trafford", 5, 25000.0, 12000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Football", new DateTime(2024, 9, 19, 12, 35, 29, 156, DateTimeKind.Local).AddTicks(1412), "Camp Nou is the home stadium of FC Barcelona since its completion in 1957. With a seating capacity of 99,354, it is the largest stadium in Spain and Europe, and the third largest football stadium in the world in capacity.", "", "Camp Nou", 7, 2000.0, 15000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Football", new DateTime(2024, 9, 19, 12, 35, 29, 156, DateTimeKind.Local).AddTicks(1413), "The Santiago Bernabéu Stadium is a football stadium in Madrid, Spain. With a current seating capacity of 81,044, it has been the home stadium of Real Madrid since its completion in 1947.", "", "Santiago Bernabeu", 2, 60000.0, 18000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UFSs");
        }
    }
}

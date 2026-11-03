using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VMS_Hisham_El_Shiraida.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleInfo",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInfo", x => x.VehicleId);
                });

            migrationBuilder.InsertData(
                table: "VehicleInfo",
                columns: new[] { "VehicleId", "Make", "Price", "PurchaseDate", "Type", "Year" },
                values: new object[,]
                {
                    { 1, "Ford F-150", 42500.00m, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2021 },
                    { 2, "Toyota Camry", 27800.00m, new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2020 },
                    { 3, "Honda Odyssey", 33400.00m, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2019 },
                    { 4, "Toyota RAV4", 36900.00m, new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2022 },
                    { 5, "Ford Mustang", 48200.00m, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2023 },
                    { 6, "Chevrolet Silverado", 45100.00m, new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2021 },
                    { 7, "Honda Civic", 26500.00m, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2022 },
                    { 8, "Chrysler Pacifica", 35800.00m, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2020 },
                    { 9, "Jeep Grand Cherokee", 51200.00m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2023 },
                    { 10, "Chevrolet Camaro", 43700.00m, new DateTime(2022, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2022 },
                    { 11, "RAM 1500", 54900.00m, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleInfo");
        }
    }
}

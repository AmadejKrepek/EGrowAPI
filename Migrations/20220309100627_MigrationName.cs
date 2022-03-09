using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrowAPI.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    SoilTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    AmbientTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    UvIndex = table.Column<int>(type: "int", nullable: false),
                    SolarRadiation = table.Column<int>(type: "int", nullable: false),
                    LeafWetness = table.Column<int>(type: "int", nullable: false),
                    AmbientHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    SoilHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    GrowthCm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorData");
        }
    }
}

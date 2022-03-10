using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace EGrowAPI.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserGuid = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    UserRegistration = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DeviceGuid = table.Column<string>(type: "text", nullable: true),
                    WaterTankLevel = table.Column<int>(type: "int", nullable: false),
                    FertilizerLevel = table.Column<int>(type: "int", nullable: false),
                    HasError = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    DeviceManufactured = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeviceRegisteredToUser = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    SensorDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    SoilTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    AmbientTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    UvIndex = table.Column<int>(type: "int", nullable: false),
                    SolarRadiation = table.Column<int>(type: "int", nullable: false),
                    LeafWetness = table.Column<int>(type: "int", nullable: false),
                    AmbientHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    SoilHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    GrowthCm = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.SensorDataId);
                    table.ForeignKey(
                        name: "FK_SensorData_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PlantName = table.Column<string>(type: "text", nullable: true),
                    PlantDescription = table.Column<string>(type: "text", nullable: true),
                    PlantType = table.Column<string>(type: "text", nullable: true),
                    Instructions = table.Column<string>(type: "text", nullable: true),
                    OptimalSoilTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    OptimalAmbientTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    OptimalUvIndex = table.Column<int>(type: "int", nullable: false),
                    OptimalSolarRadiation = table.Column<int>(type: "int", nullable: false),
                    OptimalLeafWetness = table.Column<int>(type: "int", nullable: false),
                    OptimalAmbientHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    OptimalSoilHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    FullyGrownCm = table.Column<int>(type: "int", nullable: false),
                    SensorDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plant_SensorData_SensorDataId",
                        column: x => x.SensorDataId,
                        principalTable: "SensorData",
                        principalColumn: "SensorDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_SensorDataId",
                table: "Plant",
                column: "SensorDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_DeviceId",
                table: "SensorData",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

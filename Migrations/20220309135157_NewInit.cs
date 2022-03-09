using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrowAPI.Migrations
{
    public partial class NewInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserGuid = table.Column<string>(type: "varchar(767)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserGuid);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceGuid = table.Column<string>(type: "varchar(767)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceGuid);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserGuid = table.Column<string>(type: "varchar(767)", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    AccountUserGuid = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserGuid);
                    table.ForeignKey(
                        name: "FK_User_Accounts_AccountUserGuid",
                        column: x => x.AccountUserGuid,
                        principalTable: "Accounts",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    SensorDataGuid = table.Column<string>(type: "varchar(767)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    SoilTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    AmbientTemperatureCelsius = table.Column<double>(type: "double", nullable: false),
                    UvIndex = table.Column<int>(type: "int", nullable: false),
                    SolarRadiation = table.Column<int>(type: "int", nullable: false),
                    LeafWetness = table.Column<int>(type: "int", nullable: false),
                    AmbientHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    SoilHumidityPercentage = table.Column<int>(type: "int", nullable: false),
                    GrowthCm = table.Column<int>(type: "int", nullable: false),
                    DeviceGuid = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.SensorDataGuid);
                    table.ForeignKey(
                        name: "FK_SensorData_Devices_DeviceGuid",
                        column: x => x.DeviceGuid,
                        principalTable: "Devices",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_DeviceGuid",
                table: "SensorData",
                column: "DeviceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountUserGuid",
                table: "User",
                column: "AccountUserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}

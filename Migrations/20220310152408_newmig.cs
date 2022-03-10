using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrowAPI.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UserRegistration",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PlantName",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantType",
                table: "SensorData",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRegistration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlantName",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "PlantType",
                table: "SensorData");
        }
    }
}

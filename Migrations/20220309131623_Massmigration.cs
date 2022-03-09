using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrowAPI.Migrations
{
    public partial class Massmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AccountUserId",
                table: "User",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DeviceUserId",
                table: "SensorData",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountUserId",
                table: "User",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_DeviceUserId",
                table: "SensorData",
                column: "DeviceUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorData_Devices_DeviceUserId",
                table: "SensorData",
                column: "DeviceUserId",
                principalTable: "Devices",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Accounts_AccountUserId",
                table: "User",
                column: "AccountUserId",
                principalTable: "Accounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorData_Devices_DeviceUserId",
                table: "SensorData");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Accounts_AccountUserId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_SensorData_DeviceUserId",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "AccountUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeviceUserId",
                table: "SensorData");
        }
    }
}

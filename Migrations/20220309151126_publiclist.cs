using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrowAPI.Migrations
{
    public partial class publiclist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGuid",
                table: "Devices",
                type: "varchar(767)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserGuid",
                table: "Devices",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Users_UserGuid",
                table: "Devices",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "UserGuid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Users_UserGuid",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UserGuid",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Devices");
        }
    }
}

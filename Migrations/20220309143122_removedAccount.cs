using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrowAPI.Migrations
{
    public partial class removedAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Accounts_AccountUserGuid",
                table: "User");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountUserGuid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountUserGuid",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountUserGuid",
                table: "User",
                type: "varchar(767)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountUserGuid",
                table: "User",
                column: "AccountUserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Accounts_AccountUserGuid",
                table: "User",
                column: "AccountUserGuid",
                principalTable: "Accounts",
                principalColumn: "UserGuid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

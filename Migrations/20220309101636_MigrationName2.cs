using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace EGrowAPI.Migrations
{
    public partial class MigrationName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SensorData",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Id",
                table: "SensorData",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }
    }
}

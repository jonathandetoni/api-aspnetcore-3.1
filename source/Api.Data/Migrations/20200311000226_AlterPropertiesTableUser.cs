using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterPropertiesTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "user");

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaHash",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaSalt",
                table: "user",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "user");

            migrationBuilder.DropColumn(
                name: "SenhaSalt",
                table: "user");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "user",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);
        }
    }
}

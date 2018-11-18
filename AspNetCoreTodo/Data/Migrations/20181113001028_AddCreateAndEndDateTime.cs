using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTodo.Data.Migrations
{
    public partial class AddCreateAndEndDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDateTime",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndDateTime",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Items");
        }
    }
}

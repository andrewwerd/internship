using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class AddGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Barcode",
                table: "Customers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Customers");
        }
    }
}

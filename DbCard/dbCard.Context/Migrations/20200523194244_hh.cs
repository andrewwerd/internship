using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class hh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilialAddress",
                table: "TransactionHistory");

            migrationBuilder.RenameColumn(
                name: "AccumulatingPercent",
                table: "PremiumDiscounts",
                newName: "AccumulationPercent");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TransactionHistory",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TransactionHistory");

            migrationBuilder.RenameColumn(
                name: "AccumulationPercent",
                table: "PremiumDiscounts",
                newName: "AccumulatingPercent");

            migrationBuilder.AddColumn<string>(
                name: "FilialAddress",
                table: "TransactionHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}

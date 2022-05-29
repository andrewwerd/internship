using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class EditPartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BirthdayDiscount",
                table: "Partners",
                type: "decimal(3, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BirthdayDiscount",
                table: "Partners",
                type: "decimal(3, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3, 2)",
                oldNullable: true);
        }
    }
}

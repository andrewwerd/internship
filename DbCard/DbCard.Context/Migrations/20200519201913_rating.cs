using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Partners",
                type: "decimal(4, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BirthdayDiscount",
                table: "Partners",
                type: "decimal(4, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3, 2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Partners",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BirthdayDiscount",
                table: "Partners",
                type: "decimal(3, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 2)",
                oldNullable: true);
        }
    }
}

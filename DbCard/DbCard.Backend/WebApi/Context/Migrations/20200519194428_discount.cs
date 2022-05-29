using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "StandartDiscounts",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOfDiscount",
                table: "StandartDiscounts",
                type: "decimal(10, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "PremiumDiscounts",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AccumulatingPercent",
                table: "PremiumDiscounts",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "StandartDiscounts",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOfDiscount",
                table: "StandartDiscounts",
                type: "decimal(4, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "PremiumDiscounts",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AccumulatingPercent",
                table: "PremiumDiscounts",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class TransactionEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TransactionHistory");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "TransactionHistory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SubcategoryId",
                table: "TransactionHistory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CategoryId",
                table: "TransactionHistory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_SubcategoryId",
                table: "TransactionHistory",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Categories_CategoryId",
                table: "TransactionHistory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Subcategories_SubcategoryId",
                table: "TransactionHistory",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Categories_CategoryId",
                table: "TransactionHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Subcategories_SubcategoryId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_CategoryId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_SubcategoryId",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "TransactionHistory");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TransactionHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class CategoriesConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerSubcategories");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Partners",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SubcategoryId",
                table: "Partners",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_CategoryId",
                table: "Partners",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_SubcategoryId",
                table: "Partners",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Categories_CategoryId",
                table: "Partners",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Subcategories_SubcategoryId",
                table: "Partners",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Categories_CategoryId",
                table: "Partners");

            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Subcategories_SubcategoryId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_CategoryId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_SubcategoryId",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Partners");

            migrationBuilder.CreateTable(
                name: "PartnerSubcategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    SubcategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerSubcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerSubcategories_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartnerSubcategories_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerSubcategories_PartnerId",
                table: "PartnerSubcategories",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerSubcategories_SubcategoryId",
                table: "PartnerSubcategories",
                column: "SubcategoryId");
        }
    }
}

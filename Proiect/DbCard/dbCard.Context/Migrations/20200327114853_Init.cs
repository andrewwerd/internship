using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dbCard.Context.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Category = table.Column<string>(maxLength: 40, nullable: false, defaultValueSql: "('UNIVERSAL')"),
                    Rating = table.Column<decimal>(type: "decimal(2, 2)", nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: false),
                    BirthdayDiscount = table.Column<decimal>(type: "decimal(3, 2)", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersBalances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AccumulatedAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    ResetDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsPremium = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    PartnerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersBalances_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersBalances_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoritePartners",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CustomerId = table.Column<long>(nullable: false),
                    PartnerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePartners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePartners_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritePartners_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filials",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    PartnerId = table.Column<long>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filials_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    Body = table.Column<string>(maxLength: 4000, nullable: false),
                    ShortBody = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PartnerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PremiumDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PriceOfDiscount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(2, 2)", nullable: false),
                    AccumulationPercent = table.Column<decimal>(type: "decimal(2, 2)", nullable: false),
                    PartnerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremiumDiscounts_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Body = table.Column<string>(maxLength: 1000, nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    NumbersOfLike = table.Column<int>(nullable: false),
                    NumbersOfDislike = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AnswerReview = table.Column<long>(nullable: true),
                    PartnerId = table.Column<long>(nullable: true),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Reviews_AnswerReview",
                        column: x => x.AnswerReview,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StandartDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AmountOfDiscount = table.Column<decimal>(type: "decimal(4, 2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(2, 2)", nullable: false),
                    PartnerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandartDiscounts_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    HouseNumber = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    FilialId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Filials_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PartnerName = table.Column<string>(maxLength: 40, nullable: false),
                    FilialAddress = table.Column<string>(maxLength: 40, nullable: false),
                    Category = table.Column<string>(maxLength: 40, nullable: false),
                    AllAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    AmountForPay = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    AccumulationAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    FilialId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Filials_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_FilialId",
                table: "Addresses",
                column: "FilialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBalances_CustomerId",
                table: "CustomersBalances",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBalances_PartnerId",
                table: "CustomersBalances",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePartners_CustomerId",
                table: "FavoritePartners",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePartners_PartnerId",
                table: "FavoritePartners",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Filials_PartnerId",
                table: "Filials",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Filials_PhoneNumber",
                table: "Filials",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_PartnerId",
                table: "News",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_UserId",
                table: "Partners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PremiumDiscounts_PartnerId",
                table: "PremiumDiscounts",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AnswerReview",
                table: "Reviews",
                column: "AnswerReview");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PartnerId",
                table: "Reviews",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_StandartDiscounts_PartnerId",
                table: "StandartDiscounts",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CustomerId",
                table: "TransactionHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_FilialId",
                table: "TransactionHistory",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CustomersBalances");

            migrationBuilder.DropTable(
                name: "FavoritePartners");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PremiumDiscounts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "StandartDiscounts");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Filials");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

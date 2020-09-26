using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Role = table.Column<short>(type: "SMALLINT", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    IdArticle = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    ArticleTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArticleAuthor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ArticleBody = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ArticleBanner = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.IdArticle);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    IdCourier = table.Column<Guid>(nullable: false),
                    CourierName = table.Column<string>(nullable: true),
                    CourierPhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    CourierStatus = table.Column<short>(type: "SMALLINT", maxLength: 2, nullable: false),
                    CourierPlateNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CourierArea = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.IdCourier);
                });

            migrationBuilder.CreateTable(
                name: "DetailOrders",
                columns: table => new
                {
                    IdDetailOrder = table.Column<Guid>(nullable: false),
                    IdOrder = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    IdProducts = table.Column<Guid>(type: "Uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOrders", x => x.IdDetailOrder);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    IdDiscount = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    DiscountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DiscountBanner = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Voucher = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.IdDiscount);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TanggalOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusOrder = table.Column<short>(type: "SMALLINT", maxLength: 1, nullable: false),
                    IdCourier = table.Column<Guid>(type: "Uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VariantName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Cost = table.Column<long>(type: "BIGINT", maxLength: 50, nullable: false),
                    ConstAmount = table.Column<short>(type: "SMALLINT", maxLength: 12, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsAvailable = table.Column<bool>(type: "BIT", nullable: false),
                    Stock = table.Column<short>(type: "SMALLINT", maxLength: 12, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDealoftheDay = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsProducts",
                columns: table => new
                {
                    IdReviews = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    IdProducts = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    Rating = table.Column<short>(type: "SMALLINT", maxLength: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsProducts", x => x.IdReviews);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Gender = table.Column<short>(type: "SMALLINT", maxLength: 1, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Hobby = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    LastOrder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalOrder = table.Column<short>(type: "SMALLINT", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Password",
                table: "Admins",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Role",
                table: "Admins",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Username",
                table: "Admins",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleAuthor",
                table: "Articles",
                column: "ArticleAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleBody",
                table: "Articles",
                column: "ArticleBody");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleDate",
                table: "Articles",
                column: "ArticleDate");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleTitle",
                table: "Articles",
                column: "ArticleTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdArticle",
                table: "Articles",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IdCategory",
                table: "Categories",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageUrl",
                table: "Categories",
                column: "ImageUrl");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_CourierArea",
                table: "Couriers",
                column: "CourierArea");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_CourierName",
                table: "Couriers",
                column: "CourierName");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_CourierPhoneNumber",
                table: "Couriers",
                column: "CourierPhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_CourierPlateNumber",
                table: "Couriers",
                column: "CourierPlateNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_CourierStatus",
                table: "Couriers",
                column: "CourierStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_IdCourier",
                table: "Couriers",
                column: "IdCourier");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrders_IdDetailOrder",
                table: "DetailOrders",
                column: "IdDetailOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrders_IdOrder",
                table: "DetailOrders",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrders_IdProducts",
                table: "DetailOrders",
                column: "IdProducts");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Content",
                table: "Discounts",
                column: "Content");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountEnd",
                table: "Discounts",
                column: "DiscountEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountName",
                table: "Discounts",
                column: "DiscountName");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountStart",
                table: "Discounts",
                column: "DiscountStart");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountType",
                table: "Discounts",
                column: "DiscountType");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_IdDiscount",
                table: "Discounts",
                column: "IdDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmailUser",
                table: "Orders",
                column: "EmailUser");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdOrder",
                table: "Orders",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrder",
                table: "Orders",
                column: "StatusOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BaseColor",
                table: "Products",
                column: "BaseColor");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryName",
                table: "Products",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ConstAmount",
                table: "Products",
                column: "ConstAmount");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Cost",
                table: "Products",
                column: "Cost");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProduct",
                table: "Products",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageUrl",
                table: "Products",
                column: "ImageUrl");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsAvailable",
                table: "Products",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDealoftheDay",
                table: "Products",
                column: "IsDealoftheDay");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Stock",
                table: "Products",
                column: "Stock");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VariantName",
                table: "Products",
                column: "VariantName");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsProducts_IdProducts",
                table: "ReviewsProducts",
                column: "IdProducts");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsProducts_IdReviews",
                table: "ReviewsProducts",
                column: "IdReviews");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Address",
                table: "Users",
                column: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Birthday",
                table: "Users",
                column: "Birthday");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Gender",
                table: "Users",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Hobby",
                table: "Users",
                column: "Hobby");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageUrl",
                table: "Users",
                column: "ImageUrl");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastOrder",
                table: "Users",
                column: "LastOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Password",
                table: "Users",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TotalOrder",
                table: "Users",
                column: "TotalOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ZipCode",
                table: "Users",
                column: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropTable(
                name: "DetailOrders");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ReviewsProducts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

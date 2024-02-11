using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopsRU.Persistence.Context.Migrations.SQL
{
    /// <inheritdoc />
    public partial class database_created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(3562)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(2699)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(8263)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalFixedDiscountAmount = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    TotalOrderAmount = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    TotalDiscountAmount = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    IsFixedDiscountApplied = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 120, DateTimeKind.Local).AddTicks(2540)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(415)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 118, DateTimeKind.Local).AddTicks(9246)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    RuleJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 118, DateTimeKind.Local).AddTicks(5037)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDiscounts_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDiscounts_Discounts_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LineAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDiscountApplied = table.Column<bool>(type: "bit", nullable: false),
                    LineDiscountAmount = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 11, 18, 57, 53, 120, DateTimeKind.Local).AddTicks(6109)),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4323), "Mutfak" },
                    { 2, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4331), "Mobilya" },
                    { 3, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4332), "Market" },
                    { 4, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(4333), "Aydınlatma" }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Type" },
                values: new object[,]
                {
                    { 1, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(3471), "Mağaza Çalışanı" },
                    { 2, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(3479), "Mağaza Üyesi" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "DiscountRate", "DiscountType" },
                values: new object[,]
                {
                    { 1, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(9019), "Mağaza çalışanı için belirlenmiş indirim oranı", 30, "%" },
                    { 2, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(9024), "Mağaza üyesi iiçin belirlenmiş indirim oranı", 10, "%" },
                    { 3, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(9026), "Sadık müşteri  için belirlenmiş indirim oranı", 5, "%" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerTypeId", "FirstName", "JoiningDate", "LastName" },
                values: new object[,]
                {
                    { 1, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(162), 1, "EVREN", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(167), "AKTAŞ" },
                    { 2, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(168), 2, "ECE", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(168), "DAĞDELEN" },
                    { 3, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(169), 1, "İBRAHİM", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(170), "AKIŞIK" },
                    { 4, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(171), 2, "GİZEM", new DateTime(2024, 2, 11, 18, 57, 53, 119, DateTimeKind.Local).AddTicks(172), "KURTCUOĞLU" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedOn", "Description", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1332), null, "Gardırop", 3000m, 10 },
                    { 2, 2, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1338), null, "Fırın", 4000m, 10 },
                    { 3, 3, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1340), null, "Fıstık Ezmesi", 85m, 10 },
                    { 4, 4, "EVREN AKTAŞ", new DateTime(2024, 2, 11, 18, 57, 53, 121, DateTimeKind.Local).AddTicks(1342), null, "ModeLight Işıl 3'lü Avize", 4000m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDiscounts_CustomerTypeId",
                table: "CustomerDiscounts",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDiscounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

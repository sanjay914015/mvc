using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Inventory.Migrations
{
    public partial class AddDataToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AddModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<int>(type: "int", nullable: false),
                    Beverages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyConsume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_category_ProductList_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "ProductList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "distributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distributor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_distributor_ProductList_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "ProductList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "manufacturercompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<long>(type: "bigint", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturercompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_manufacturercompany_ProductList_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "ProductList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_ProductsId",
                table: "category",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_distributor_ProductsId",
                table: "distributor",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_manufacturercompany_ProductsId",
                table: "manufacturercompany",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "distributor");

            migrationBuilder.DropTable(
                name: "manufacturercompany");

            migrationBuilder.DropTable(
                name: "ProductList");
        }
    }
}

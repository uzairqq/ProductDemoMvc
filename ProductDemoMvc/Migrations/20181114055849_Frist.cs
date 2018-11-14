using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductDemoMvc.Migrations
{
    public partial class Frist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhysicalPath = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { 1, new DateTime(2018, 11, 14, 10, 58, 49, 270, DateTimeKind.Local), "Order1" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { 2, new DateTime(2018, 11, 14, 10, 58, 49, 271, DateTimeKind.Local), "Order1" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { 3, new DateTime(2018, 11, 14, 5, 58, 49, 271, DateTimeKind.Utc), "Order2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "OrderId", "PhysicalPath", "Price" },
                values: new object[] { 1, "Apple", 1, null, 1.2m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "OrderId", "PhysicalPath", "Price" },
                values: new object[] { 2, "Orange", 1, null, 2.4m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "OrderId", "PhysicalPath", "Price" },
                values: new object[] { 3, "Graphes", 2, null, 3.4m });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

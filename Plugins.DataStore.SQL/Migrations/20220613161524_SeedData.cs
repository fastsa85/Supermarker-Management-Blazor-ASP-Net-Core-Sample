using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Beverage", "Beverage" },
                    { 2, "Bakery", "Bakery" },
                    { 3, "Meat", "Meat" }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionId", "BeforeQuantity", "CashierName", "Price", "ProductId", "ProductName", "SoldQuantity", "Timestamp" },
                values: new object[] { 1, 110, "Alex", 1.98m, 1, "Iced Tea", 10, new DateTime(2022, 6, 13, 19, 15, 24, 379, DateTimeKind.Local).AddTicks(7949) });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Iced Tea", 1.99m, 100 },
                    { 2, 1, "Ginger Ale", 0.99m, 99 },
                    { 3, 2, "Whole Wheat Bread", 1.19m, 199 },
                    { 4, 2, "White Bread", 1.50m, 88 },
                    { 5, 2, "Donut", 0.55m, 51 },
                    { 6, 3, "Pork", 5.01m, 24 },
                    { 7, 3, "Beef", 4.69m, 19 },
                    { 8, 3, "Chicken", 3.99m, 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CryptoScanner.UI.Migrations
{
    /// <inheritdoc />
    public partial class initcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "ApiId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "bitcoin", "Bitcoin", 514135m },
                    { 2, "dogecoin", "Dogecoin", 0.854076m },
                    { 3, "tether", "Tether", 10.59m },
                    { 4, "solana", "Solana", 1158.27m },
                    { 5, "cardano", "Cardano", 5.7m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

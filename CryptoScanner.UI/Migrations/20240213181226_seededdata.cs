using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CryptoScanner.UI.Migrations
{
    /// <inheritdoc />
    public partial class seededdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApiId", "Name", "Price" },
                values: new object[] { "bitcoin", "Bitcoin", 514135m });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApiId", "Name", "Price" },
                values: new object[] { "dogecoin", "Dogecoin", 0.854076m });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApiId", "Name", "Price" },
                values: new object[] { "tether", "Tether", 10.59m });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "ApiId", "Name", "Price" },
                values: new object[,]
                {
                    { 6, "solana", "Solana", 1158.27m },
                    { 7, "cardano", "Cardano", 5.7m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApiId", "Name", "Price" },
                values: new object[] { "tether", "Tether", 10.59m });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApiId", "Name", "Price" },
                values: new object[] { "solana", "Solana", 1158.27m });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApiId", "Name", "Price" },
                values: new object[] { "cardano", "Cardano", 5.7m });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "ApiId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "bitcoin", "Bitcoin", 514135m },
                    { 2, "dogecoin", "Dogecoin", 0.854076m }
                });
        }
    }
}

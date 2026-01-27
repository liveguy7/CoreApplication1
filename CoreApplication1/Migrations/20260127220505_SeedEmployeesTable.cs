using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "empTarget",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1, "mark@na.com", "Mark" },
                    { 2, 1, "pan@na.com", "Pan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "empTarget",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "empTarget",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

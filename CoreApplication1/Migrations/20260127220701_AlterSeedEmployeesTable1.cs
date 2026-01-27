using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AlterSeedEmployeesTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "empTarget",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 3, 1, "ben@na.com", "Ben" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "empTarget",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoPathColumn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath1",
                table: "empTarget",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "empTarget",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath1",
                value: null);

            migrationBuilder.UpdateData(
                table: "empTarget",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath1",
                value: null);

            migrationBuilder.UpdateData(
                table: "empTarget",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath1",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath1",
                table: "empTarget");
        }
    }
}

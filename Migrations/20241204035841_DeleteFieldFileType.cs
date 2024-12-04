using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pelengkap.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFieldFileType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "FileDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "FileDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

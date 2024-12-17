using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pelengkap.Migrations
{
    /// <inheritdoc />
    public partial class AlterJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentsJoin_DepartmentId",
                table: "StudentsJoin",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsJoin_TeacherId",
                table: "DepartmentsJoin",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsJoin_TeachersJoin_TeacherId",
                table: "DepartmentsJoin",
                column: "TeacherId",
                principalTable: "TeachersJoin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsJoin_DepartmentsJoin_DepartmentId",
                table: "StudentsJoin",
                column: "DepartmentId",
                principalTable: "DepartmentsJoin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsJoin_TeachersJoin_TeacherId",
                table: "DepartmentsJoin");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsJoin_DepartmentsJoin_DepartmentId",
                table: "StudentsJoin");

            migrationBuilder.DropIndex(
                name: "IX_StudentsJoin_DepartmentId",
                table: "StudentsJoin");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentsJoin_TeacherId",
                table: "DepartmentsJoin");
        }
    }
}

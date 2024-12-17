using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pelengkap.Migrations
{
    /// <inheritdoc />
    public partial class alteragain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsJoin_DepartmentsJoin_DepartmentId",
                table: "StudentsJoin");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "StudentsJoin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsJoin_DepartmentsJoin_DepartmentId",
                table: "StudentsJoin",
                column: "DepartmentId",
                principalTable: "DepartmentsJoin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsJoin_DepartmentsJoin_DepartmentId",
                table: "StudentsJoin");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "StudentsJoin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsJoin_DepartmentsJoin_DepartmentId",
                table: "StudentsJoin",
                column: "DepartmentId",
                principalTable: "DepartmentsJoin",
                principalColumn: "Id");
        }
    }
}

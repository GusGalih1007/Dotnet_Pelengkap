using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pelengkap.Migrations
{
    /// <inheritdoc />
    public partial class AlterAgain1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsJoin_TeachersJoin_TeacherId",
                table: "DepartmentsJoin");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "DepartmentsJoin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsJoin_TeachersJoin_TeacherId",
                table: "DepartmentsJoin",
                column: "TeacherId",
                principalTable: "TeachersJoin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsJoin_TeachersJoin_TeacherId",
                table: "DepartmentsJoin");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "DepartmentsJoin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsJoin_TeachersJoin_TeacherId",
                table: "DepartmentsJoin",
                column: "TeacherId",
                principalTable: "TeachersJoin",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class newModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StaffPhone",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStudents_BatchId",
                table: "BatchStudents",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStudents_StudentId",
                table: "BatchStudents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_Batches_BatchId",
                table: "BatchStudents",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_Students_StudentId",
                table: "BatchStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_Batches_BatchId",
                table: "BatchStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_Students_StudentId",
                table: "BatchStudents");

            migrationBuilder.DropIndex(
                name: "IX_BatchStudents_BatchId",
                table: "BatchStudents");

            migrationBuilder.DropIndex(
                name: "IX_BatchStudents_StudentId",
                table: "BatchStudents");

            migrationBuilder.AlterColumn<string>(
                name: "StaffPhone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}

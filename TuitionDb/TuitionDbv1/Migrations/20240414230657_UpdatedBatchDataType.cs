using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBatchDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Subjects_SubjectsSubjectId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_SubjectsSubjectId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "SubjectsSubjectId",
                table: "Batches");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Batches",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Batches",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_SubjectId",
                table: "Batches",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Subjects_SubjectId",
                table: "Batches",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Subjects_SubjectId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_SubjectId",
                table: "Batches");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubjectsSubjectId",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batches_SubjectsSubjectId",
                table: "Batches",
                column: "SubjectsSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Subjects_SubjectsSubjectId",
                table: "Batches",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

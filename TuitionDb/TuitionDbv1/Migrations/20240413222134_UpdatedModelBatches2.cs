using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelBatches2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Staffs_StaffsStaffId",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "StaffsStaffId",
                table: "Batches",
                newName: "SubjectsSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_StaffsStaffId",
                table: "Batches",
                newName: "IX_Batches_SubjectsSubjectId");

            migrationBuilder.AlterColumn<string>(
                name: "StaffName",
                table: "Staffs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "StaffEmail",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "Batch",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batches_Batch",
                table: "Batches",
                column: "Batch");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Staffs_Batch",
                table: "Batches",
                column: "Batch",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Subjects_SubjectsSubjectId",
                table: "Batches",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Staffs_Batch",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Subjects_SubjectsSubjectId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_Batch",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "Batches",
                newName: "StaffsStaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_SubjectsSubjectId",
                table: "Batches",
                newName: "IX_Batches_StaffsStaffId");

            migrationBuilder.AlterColumn<string>(
                name: "StaffName",
                table: "Staffs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "StaffEmail",
                table: "Staffs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Staffs_StaffsStaffId",
                table: "Batches",
                column: "StaffsStaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

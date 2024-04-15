using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesBatchModel : Migration
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
                newName: "Batch");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_StaffsStaffId",
                table: "Batches",
                newName: "IX_Batches_Batch");

            migrationBuilder.AlterColumn<int>(
                name: "StudentPhone",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "StaffEmail",
                table: "Staffs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Staffs_Batch",
                table: "Batches",
                column: "Batch",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Staffs_Batch",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "Batch",
                table: "Batches",
                newName: "StaffsStaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_Batch",
                table: "Batches",
                newName: "IX_Batches_StaffsStaffId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentPhone",
                table: "Students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StaffEmail",
                table: "Staffs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

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

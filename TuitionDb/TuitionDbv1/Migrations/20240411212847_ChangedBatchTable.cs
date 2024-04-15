using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBatchTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Staffs_StaffId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_StaffId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Batches",
                newName: "StaffsStaffId");

            migrationBuilder.AddColumn<string>(
                name: "StaffName",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_StaffsStaffId",
                table: "Batches",
                column: "StaffsStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Staffs_StaffsStaffId",
                table: "Batches",
                column: "StaffsStaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Staffs_StaffsStaffId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_StaffsStaffId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "StaffName",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "StaffsStaffId",
                table: "Batches",
                newName: "SubjectId");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batches_StaffId",
                table: "Batches",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Staffs_StaffId",
                table: "Batches",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

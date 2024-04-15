using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelBatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "StaffsStaffId",
                table: "Batches",
                newName: "Batch");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_StaffsStaffId",
                table: "Batches",
                newName: "IX_Batches_Batch");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Staffs_Batch",
                table: "Batches",
                column: "Batch",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

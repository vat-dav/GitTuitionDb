using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBatchModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Staffs_Batch",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_Batch",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Batches");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Staffs_StaffId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_StaffId",
                table: "Batches");

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
        }
    }
}

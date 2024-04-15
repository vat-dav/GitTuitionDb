using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Batches",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "StaffName",
                table: "Batches",
                newName: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Batches",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Batches",
                newName: "StaffName");
        }
    }
}

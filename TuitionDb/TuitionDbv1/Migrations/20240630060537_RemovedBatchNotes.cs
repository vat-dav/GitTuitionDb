using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class RemovedBatchNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNotes",
                table: "Batches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchNotes",
                table: "Batches",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }
    }
}

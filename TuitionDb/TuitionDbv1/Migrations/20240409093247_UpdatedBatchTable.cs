using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBatchTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Batches");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Batches");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class NewBatchStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchFee");

            migrationBuilder.DropColumn(
                name: "BatchDay",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BatchTime",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AmountToPay",
                table: "BatchStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Received",
                table: "BatchStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "BatchStudents");

            migrationBuilder.DropColumn(
                name: "Received",
                table: "BatchStudents");

            migrationBuilder.AddColumn<int>(
                name: "BatchDay",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BatchTime",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BatchFee",
                columns: table => new
                {
                    FeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AmountToPay = table.Column<int>(type: "int", nullable: false),
                    Received = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchFee", x => x.FeeId);
                    table.ForeignKey(
                        name: "FK_BatchFee_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchFee_StudentId",
                table: "BatchFee",
                column: "StudentId");
        }
    }
}

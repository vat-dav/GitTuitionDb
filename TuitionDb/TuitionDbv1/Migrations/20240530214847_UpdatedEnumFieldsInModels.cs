using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEnumFieldsInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewBatchStudentsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ViewBatchStudents",
                columns: table => new
                {
                    ViewBatchStudentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchesBatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewBatchStudents", x => x.ViewBatchStudentsId);
                    table.ForeignKey(
                        name: "FK_ViewBatchStudents_Batches_BatchesBatchId",
                        column: x => x.BatchesBatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ViewBatchStudentsId",
                table: "Students",
                column: "ViewBatchStudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewBatchStudents_BatchesBatchId",
                table: "ViewBatchStudents",
                column: "BatchesBatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ViewBatchStudents_ViewBatchStudentsId",
                table: "Students",
                column: "ViewBatchStudentsId",
                principalTable: "ViewBatchStudents",
                principalColumn: "ViewBatchStudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ViewBatchStudents_ViewBatchStudentsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ViewBatchStudents");

            migrationBuilder.DropIndex(
                name: "IX_Students_ViewBatchStudentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ViewBatchStudentsId",
                table: "Students");
        }
    }
}

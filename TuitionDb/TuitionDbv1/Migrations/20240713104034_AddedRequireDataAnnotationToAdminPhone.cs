using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class AddedRequireDataAnnotationToAdminPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffPhone",
                table: "AspNetUsers",
                newName: "AdminPhone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminPhone",
                table: "AspNetUsers",
                newName: "StaffPhone");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class newCustomFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminFirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminLastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminLastName",
                table: "AspNetUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuitionDbv1.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassSubject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "PplParent",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentPhone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PplParent", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "PplStaff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PplStaff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ClassSubjectSubjectId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    PplStaffStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_Class_ClassSubject_ClassSubjectSubjectId",
                        column: x => x.ClassSubjectSubjectId,
                        principalTable: "ClassSubject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_PplStaff_PplStaffStaffId",
                        column: x => x.PplStaffStaffId,
                        principalTable: "PplStaff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudent",
                columns: table => new
                {
                    BatchStudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudent", x => x.BatchStudentId);
                    table.ForeignKey(
                        name: "FK_ClassStudent_Class_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Class",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PplStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchTime = table.Column<int>(type: "int", nullable: false),
                    BatchDay = table.Column<int>(type: "int", nullable: false),
                    YearLevel = table.Column<int>(type: "int", nullable: false),
                    Course = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    PplParentParentId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    PplStaffStaffId = table.Column<int>(type: "int", nullable: false),
                    BatchStudentsBatchStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PplStudent", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_PplStudent_ClassStudent_BatchStudentsBatchStudentId",
                        column: x => x.BatchStudentsBatchStudentId,
                        principalTable: "ClassStudent",
                        principalColumn: "BatchStudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PplStudent_PplParent_PplParentParentId",
                        column: x => x.PplParentParentId,
                        principalTable: "PplParent",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PplStudent_PplStaff_PplStaffStaffId",
                        column: x => x.PplStaffStaffId,
                        principalTable: "PplStaff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassFee",
                columns: table => new
                {
                    FeesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    ClassStudentBatchStudentId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    PplParentParentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PplStudentStudentId = table.Column<int>(type: "int", nullable: false),
                    FeesPaid = table.Column<bool>(type: "bit", nullable: false),
                    PayMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFee", x => x.FeesId);
                    table.ForeignKey(
                        name: "FK_ClassFee_ClassStudent_ClassStudentBatchStudentId",
                        column: x => x.ClassStudentBatchStudentId,
                        principalTable: "ClassStudent",
                        principalColumn: "BatchStudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassFee_PplParent_PplParentParentId",
                        column: x => x.PplParentParentId,
                        principalTable: "PplParent",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassFee_PplStudent_PplStudentStudentId",
                        column: x => x.PplStudentStudentId,
                        principalTable: "PplStudent",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_ClassSubjectSubjectId",
                table: "Class",
                column: "ClassSubjectSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_PplStaffStaffId",
                table: "Class",
                column: "PplStaffStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFee_ClassStudentBatchStudentId",
                table: "ClassFee",
                column: "ClassStudentBatchStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFee_PplParentParentId",
                table: "ClassFee",
                column: "PplParentParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFee_PplStudentStudentId",
                table: "ClassFee",
                column: "PplStudentStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_BatchId",
                table: "ClassStudent",
                column: "BatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PplStudent_BatchStudentsBatchStudentId",
                table: "PplStudent",
                column: "BatchStudentsBatchStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PplStudent_PplParentParentId",
                table: "PplStudent",
                column: "PplParentParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PplStudent_PplStaffStaffId",
                table: "PplStudent",
                column: "PplStaffStaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassFee");

            migrationBuilder.DropTable(
                name: "PplStudent");

            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.DropTable(
                name: "PplParent");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "ClassSubject");

            migrationBuilder.DropTable(
                name: "PplStaff");
        }
    }
}

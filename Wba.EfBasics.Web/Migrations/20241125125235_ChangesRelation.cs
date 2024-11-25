using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wba.EfBasics.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                schema: "DboSchool",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                schema: "DboSchool",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "DboSchool",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                schema: "DboSchool",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalSchema: "DboSchool",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalSchema: "DboSchool",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.InsertData(
                schema: "DboSchool",
                table: "CourseTeacher",
                columns: new[] { "CoursesId", "TeachersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 52, 34, 811, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersId",
                schema: "DboSchool",
                table: "CourseTeacher",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTeacher",
                schema: "DboSchool");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                schema: "DboSchool",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "TeacherId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "TeacherId" },
                values: new object[] { new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9306), 1 });

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                schema: "DboSchool",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                schema: "DboSchool",
                table: "Courses",
                column: "TeacherId",
                principalSchema: "DboSchool",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

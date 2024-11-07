using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wba.EfBasics.Web.Migrations
{
    /// <inheritdoc />
    public partial class CustomMAnyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_StudentsId",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                schema: "DboSchool",
                table: "CourseStudent",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                schema: "DboSchool",
                table: "CourseStudent",
                newName: "CourseId");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                schema: "DboSchool",
                table: "CourseStudent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                schema: "DboSchool",
                table: "CourseStudent",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CourseId",
                schema: "DboSchool",
                table: "CourseStudent",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CourseId",
                schema: "DboSchool",
                table: "CourseStudent",
                column: "CourseId",
                principalSchema: "DboSchool",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                schema: "DboSchool",
                table: "CourseStudent",
                column: "StudentId",
                principalSchema: "DboSchool",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CourseId",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_CourseId",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "StudentId",
                schema: "DboSchool",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "Score",
                schema: "DboSchool",
                table: "CourseStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "DboSchool",
                table: "CourseStudent",
                newName: "CoursesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                schema: "DboSchool",
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                schema: "DboSchool",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                schema: "DboSchool",
                table: "CourseStudent",
                column: "CoursesId",
                principalSchema: "DboSchool",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                schema: "DboSchool",
                table: "CourseStudent",
                column: "StudentsId",
                principalSchema: "DboSchool",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

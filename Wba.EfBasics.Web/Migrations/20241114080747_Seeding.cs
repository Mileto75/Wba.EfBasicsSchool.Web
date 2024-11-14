using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wba.EfBasics.Web.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "DboSchool",
                table: "Addresses",
                columns: new[] { "Id", "Created", "Deleted", "FullAdress", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1703), null, "Langestraat 67, 8370 Blankenberge", null },
                    { 2, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1748), null, "Molenstraat 78, 8000 Brugge", null }
                });

            migrationBuilder.InsertData(
                schema: "DboSchool",
                table: "Students",
                columns: new[] { "Id", "AddressId", "Created", "Deleted", "Firstname", "Lastname", "Updated" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1757), null, "Mark", "Knopfler", null },
                    { 2, null, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1758), null, "Jimi", "Hendrix", null },
                    { 3, null, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1760), null, "Rory", "Gallagher", null },
                    { 4, null, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1762), null, "Tim", "Henson", null }
                });

            migrationBuilder.InsertData(
                schema: "DboSchool",
                table: "Teachers",
                columns: new[] { "Id", "AddressId", "Created", "Deleted", "Firstname", "Lastname", "Updated" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1752), null, "Bart", "Soete", null },
                    { 2, 1, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1755), null, "Mileto", "Di Marco", null }
                });

            migrationBuilder.InsertData(
                schema: "DboSchool",
                table: "Courses",
                columns: new[] { "Id", "Created", "Deleted", "Name", "TeacherId", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1764), null, "Web Backend", 2, null },
                    { 2, new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1766), null, "Web Frontend Advanced", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "DboSchool",
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

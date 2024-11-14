using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wba.EfBasics.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "Created",
                value: new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 35, 14, 284, DateTimeKind.Local).AddTicks(9306));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 9, 7, 46, 981, DateTimeKind.Local).AddTicks(1755));
        }
    }
}

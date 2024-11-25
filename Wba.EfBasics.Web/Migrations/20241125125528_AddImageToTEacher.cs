using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wba.EfBasics.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToTEacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "DboSchool",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1034), null });

            migrationBuilder.UpdateData(
                schema: "DboSchool",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2024, 11, 25, 13, 55, 28, 231, DateTimeKind.Local).AddTicks(1036), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "DboSchool",
                table: "Teachers");

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
        }
    }
}

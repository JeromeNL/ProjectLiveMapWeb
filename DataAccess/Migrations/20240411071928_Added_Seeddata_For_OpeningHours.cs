using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_Seeddata_For_OpeningHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DefaultOpeningHours",
                columns: new[] { "FacilityId", "WeekDay", "CloseTime", "OpenTime" },
                values: new object[,]
                {
                    { 1, 0, new TimeOnly(20, 0, 0), new TimeOnly(14, 0, 0) },
                    { 1, 1, new TimeOnly(20, 0, 0), new TimeOnly(12, 0, 0) },
                    { 1, 2, new TimeOnly(21, 0, 0), new TimeOnly(11, 0, 0) },
                    { 1, 3, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0) },
                    { 1, 4, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0) },
                    { 1, 5, new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0) },
                    { 1, 6, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0) }
                });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 19, 28, 452, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 19, 28, 452, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 19, 28, 452, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 19, 28, 452, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.InsertData(
                table: "SpecialOpeningHours",
                columns: new[] { "Date", "FacilityId", "CloseTime", "OpenTime" },
                values: new object[] { new DateOnly(2024, 4, 11), 1, new TimeOnly(23, 50, 0), new TimeOnly(6, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 0 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 11), 1 });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 18, 31, 52, 347, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 18, 31, 52, 347, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 18, 31, 52, 347, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 18, 31, 52, 347, DateTimeKind.Local).AddTicks(2140));
        }
    }
}

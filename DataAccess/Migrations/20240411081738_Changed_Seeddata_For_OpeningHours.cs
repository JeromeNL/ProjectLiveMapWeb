using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Seeddata_For_OpeningHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 0 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 1 },
                column: "OpenTime",
                value: new TimeOnly(14, 0, 0));

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(20, 0, 0), new TimeOnly(12, 0, 0) });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 3 },
                column: "OpenTime",
                value: new TimeOnly(11, 0, 0));

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 5 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0) });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 6 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0) });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 11), 1 },
                column: "CloseTime",
                value: new TimeOnly(23, 30, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 0 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(20, 0, 0), new TimeOnly(14, 0, 0) });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 1 },
                column: "OpenTime",
                value: new TimeOnly(12, 0, 0));

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(21, 0, 0), new TimeOnly(11, 0, 0) });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 3 },
                column: "OpenTime",
                value: new TimeOnly(12, 0, 0));

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 5 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0) });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 6 },
                columns: new[] { "CloseTime", "OpenTime" },
                values: new object[] { new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0) });

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

            migrationBuilder.UpdateData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 11), 1 },
                column: "CloseTime",
                value: new TimeOnly(23, 50, 0));
        }
    }
}

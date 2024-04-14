using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DefaultOpeningHours",
                columns: new[] { "FacilityId", "WeekDay", "CloseTime", "OpenTime", "ProposedFacilityId" },
                values: new object[,]
                {
                    { 2, 0, new TimeOnly(23, 59, 0), new TimeOnly(0, 0, 0), null },
                    { 3, 0, new TimeOnly(23, 59, 0), new TimeOnly(0, 0, 0), null },
                    { 2, 1, new TimeOnly(20, 0, 0), new TimeOnly(14, 0, 0), null },
                    { 3, 1, new TimeOnly(20, 0, 0), new TimeOnly(14, 0, 0), null },
                    { 2, 2, new TimeOnly(20, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 3, 2, new TimeOnly(20, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 2, 3, new TimeOnly(21, 0, 0), new TimeOnly(11, 0, 0), null },
                    { 3, 3, new TimeOnly(21, 0, 0), new TimeOnly(11, 0, 0), null },
                    { 2, 4, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 3, 4, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 2, 5, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 3, 5, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 2, 6, new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0), null },
                    { 3, 6, new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0), null }
                });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 6, 47, 454, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 6, 47, 454, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 6, 47, 454, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 6, 47, 454, DateTimeKind.Local).AddTicks(4830));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 2, 0 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 3, 0 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 1, 55, 655, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 1, 55, 655, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 1, 55, 655, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 11, 1, 55, 655, DateTimeKind.Local).AddTicks(2110));
        }
    }
}

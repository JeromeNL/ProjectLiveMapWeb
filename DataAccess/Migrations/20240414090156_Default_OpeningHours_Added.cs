using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Default_OpeningHours_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 13), 1 });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 0 },
                column: "CloseTime",
                value: new TimeOnly(23, 59, 0));

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

            migrationBuilder.InsertData(
                table: "SpecialOpeningHours",
                columns: new[] { "Date", "FacilityId", "CloseTime", "OpenTime", "ProposedFacilityId" },
                values: new object[] { new DateOnly(2024, 4, 14), 1, new TimeOnly(23, 30, 0), new TimeOnly(6, 0, 0), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 14), 1 });

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 0 },
                column: "CloseTime",
                value: new TimeOnly(0, 0, 0));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 16, 7, 5, 801, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 16, 7, 5, 801, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 16, 7, 5, 801, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 16, 7, 5, 801, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.InsertData(
                table: "SpecialOpeningHours",
                columns: new[] { "Date", "FacilityId", "CloseTime", "OpenTime", "ProposedFacilityId" },
                values: new object[] { new DateOnly(2024, 4, 13), 1, new TimeOnly(23, 30, 0), new TimeOnly(6, 0, 0), null });
        }
    }
}

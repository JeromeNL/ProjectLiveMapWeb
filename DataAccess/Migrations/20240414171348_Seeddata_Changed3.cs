using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata_Changed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 14), 1 });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 19, 13, 47, 488, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.InsertData(
                table: "SpecialOpeningHours",
                columns: new[] { "Date", "FacilityId", "CloseTime", "OpenTime", "ProposedFacilityId" },
                values: new object[] { new DateOnly(2024, 4, 16), 1, new TimeOnly(23, 30, 0), new TimeOnly(6, 0, 0), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 16), 1 });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 16, 32, 55, 540, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 16, 32, 55, 540, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 16, 32, 55, 540, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 14, 16, 32, 55, 540, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.InsertData(
                table: "SpecialOpeningHours",
                columns: new[] { "Date", "FacilityId", "CloseTime", "OpenTime", "ProposedFacilityId" },
                values: new object[] { new DateOnly(2024, 4, 14), 1, new TimeOnly(23, 30, 0), new TimeOnly(6, 0, 0), null });
        }
    }
}

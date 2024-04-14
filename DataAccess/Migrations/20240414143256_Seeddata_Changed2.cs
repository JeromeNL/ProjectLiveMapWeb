using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata_Changed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[,]
                {
                    { new DateOnly(2024, 4, 19), 1, new TimeOnly(14, 0, 0), new TimeOnly(9, 0, 0), null },
                    { new DateOnly(2024, 4, 29), 1, new TimeOnly(22, 0, 0), new TimeOnly(15, 0, 0), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 19), 1 });

            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 29), 1 });

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
    }
}

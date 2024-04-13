using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adding_date_to_servicereport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "submittedAt",
                table: "ServiceReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 42, 39, 725, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 42, 39, 725, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 42, 39, 725, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 42, 39, 725, DateTimeKind.Local).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 5,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 6,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 7,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 8,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 9,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 10,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 11,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 12,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 13,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 14,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 15,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 16,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 17,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 18,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 19,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 20,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 21,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 22,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 23,
                column: "submittedAt",
                value: null);

            migrationBuilder.InsertData(
                table: "ServiceReports",
                columns: new[] { "Id", "Description", "FacilityId", "ServiceReportCategoryId", "Title", "UserId", "submittedAt" },
                values: new object[,]
                {
                    { 24, "description24", 3, 3, "report 24", 4, null },
                    { 25, "description25", 1, 4, "report 25", 5, null },
                    { 26, "description26", 2, 5, "report 26", 6, null },
                    { 27, "description27", 3, 6, "report 27", 1, null },
                    { 28, "description28", 1, 1, "report 28", 2, null },
                    { 29, "description29", 2, 2, "report 29", 3, null },
                    { 30, "description30", 3, 3, "report 30", 4, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DropColumn(
                name: "submittedAt",
                table: "ServiceReports");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 33, 52, 569, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 33, 52, 569, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 33, 52, 569, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 33, 52, 569, DateTimeKind.Local).AddTicks(9825));
        }
    }
}

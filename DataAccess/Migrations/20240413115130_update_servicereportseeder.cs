using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_servicereportseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "submittedAt",
                table: "ServiceReports",
                newName: "SubmittedAt");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 7,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 8,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 9,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 10,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 11,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 12,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 13,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 14,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 15,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 16,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 17,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 18,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 19,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 20,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 21,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 22,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 23,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 24,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 25,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 26,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 27,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 28,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 29,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 30,
                column: "SubmittedAt",
                value: new DateTime(2024, 4, 13, 13, 51, 29, 739, DateTimeKind.Local).AddTicks(6509));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmittedAt",
                table: "ServiceReports",
                newName: "submittedAt");

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

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 24,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 25,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 26,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 27,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 28,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 29,
                column: "submittedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 30,
                column: "submittedAt",
                value: null);
        }
    }
}

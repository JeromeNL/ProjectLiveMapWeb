using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_servicereport_again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReports_ServiceReportCategories_CategoryId",
                table: "ServiceReports");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ServiceReports",
                newName: "ServiceReportCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceReports_CategoryId",
                table: "ServiceReports",
                newName: "IX_ServiceReports_ServiceReportCategoryId");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 33, 55, 639, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 33, 55, 639, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 33, 55, 639, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 33, 55, 639, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReports_ServiceReportCategories_ServiceReportCategoryId",
                table: "ServiceReports",
                column: "ServiceReportCategoryId",
                principalTable: "ServiceReportCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReports_ServiceReportCategories_ServiceReportCategoryId",
                table: "ServiceReports");

            migrationBuilder.RenameColumn(
                name: "ServiceReportCategoryId",
                table: "ServiceReports",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceReports_ServiceReportCategoryId",
                table: "ServiceReports",
                newName: "IX_ServiceReports_CategoryId");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 30, 57, 449, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 30, 57, 449, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 30, 57, 449, DateTimeKind.Local).AddTicks(7598));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 30, 57, 449, DateTimeKind.Local).AddTicks(7600));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReports_ServiceReportCategories_CategoryId",
                table: "ServiceReports",
                column: "CategoryId",
                principalTable: "ServiceReportCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

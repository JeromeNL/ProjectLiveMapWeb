using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_servicereport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ServiceReports");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ServiceReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReports_CategoryId",
                table: "ServiceReports",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReports_ServiceReportCategories_CategoryId",
                table: "ServiceReports",
                column: "CategoryId",
                principalTable: "ServiceReportCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReports_ServiceReportCategories_CategoryId",
                table: "ServiceReports");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReports_CategoryId",
                table: "ServiceReports");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ServiceReports");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ServiceReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 23, 37, 312, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 23, 37, 312, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 23, 37, 312, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 15, 23, 37, 312, DateTimeKind.Local).AddTicks(7483));
        }
    }
}

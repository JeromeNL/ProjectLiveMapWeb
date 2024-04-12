using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updating_servicereport_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReports_Facilities_facilityId",
                table: "ServiceReports");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "ServiceReports",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "facilityId",
                table: "ServiceReports",
                newName: "FacilityId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ServiceReports",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "ServiceReports",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceReports_facilityId",
                table: "ServiceReports",
                newName: "IX_ServiceReports_FacilityId");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 10, 48, 16, 623, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 10, 48, 16, 623, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 10, 48, 16, 623, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 10, 48, 16, 623, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReports_Facilities_FacilityId",
                table: "ServiceReports",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReports_Facilities_FacilityId",
                table: "ServiceReports");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ServiceReports",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "FacilityId",
                table: "ServiceReports",
                newName: "facilityId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ServiceReports",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "ServiceReports",
                newName: "category");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceReports_FacilityId",
                table: "ServiceReports",
                newName: "IX_ServiceReports_facilityId");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 14, 52, 26, 1, DateTimeKind.Local).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 14, 52, 26, 1, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 14, 52, 26, 1, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 14, 52, 26, 1, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReports_Facilities_facilityId",
                table: "ServiceReports",
                column: "facilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adding_servicereports_to_facilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProposedFacilityId",
                table: "ServiceReports",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 25, 55, 327, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 25, 55, 327, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 25, 55, 327, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 25, 55, 327, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReports_ProposedFacilityId",
                table: "ServiceReports",
                column: "ProposedFacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReports_ProposedFacilities_ProposedFacilityId",
                table: "ServiceReports",
                column: "ProposedFacilityId",
                principalTable: "ProposedFacilities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReports_ProposedFacilities_ProposedFacilityId",
                table: "ServiceReports");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReports_ProposedFacilityId",
                table: "ServiceReports");

            migrationBuilder.DropColumn(
                name: "ProposedFacilityId",
                table: "ServiceReports");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 15, 37, 3, 183, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 15, 37, 3, 183, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 15, 37, 3, 183, DateTimeKind.Local).AddTicks(3316));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 15, 37, 3, 183, DateTimeKind.Local).AddTicks(3317));
        }
    }
}

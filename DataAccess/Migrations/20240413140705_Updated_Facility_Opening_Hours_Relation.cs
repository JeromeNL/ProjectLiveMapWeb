using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Facility_Opening_Hours_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 11), 1 });

            migrationBuilder.AddColumn<int>(
                name: "ProposedFacilityId",
                table: "SpecialOpeningHours",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposedFacilityId",
                table: "DefaultOpeningHours",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 0 },
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 1 },
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 2 },
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 3 },
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 4 },
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 5 },
                column: "ProposedFacilityId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DefaultOpeningHours",
                keyColumns: new[] { "FacilityId", "WeekDay" },
                keyValues: new object[] { 1, 6 },
                column: "ProposedFacilityId",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOpeningHours_ProposedFacilityId",
                table: "SpecialOpeningHours",
                column: "ProposedFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultOpeningHours_ProposedFacilityId",
                table: "DefaultOpeningHours",
                column: "ProposedFacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultOpeningHours_ProposedFacilities_ProposedFacilityId",
                table: "DefaultOpeningHours",
                column: "ProposedFacilityId",
                principalTable: "ProposedFacilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialOpeningHours_ProposedFacilities_ProposedFacilityId",
                table: "SpecialOpeningHours",
                column: "ProposedFacilityId",
                principalTable: "ProposedFacilities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultOpeningHours_ProposedFacilities_ProposedFacilityId",
                table: "DefaultOpeningHours");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialOpeningHours_ProposedFacilities_ProposedFacilityId",
                table: "SpecialOpeningHours");

            migrationBuilder.DropIndex(
                name: "IX_SpecialOpeningHours_ProposedFacilityId",
                table: "SpecialOpeningHours");

            migrationBuilder.DropIndex(
                name: "IX_DefaultOpeningHours_ProposedFacilityId",
                table: "DefaultOpeningHours");

            migrationBuilder.DeleteData(
                table: "SpecialOpeningHours",
                keyColumns: new[] { "Date", "FacilityId" },
                keyValues: new object[] { new DateOnly(2024, 4, 13), 1 });

            migrationBuilder.DropColumn(
                name: "ProposedFacilityId",
                table: "SpecialOpeningHours");

            migrationBuilder.DropColumn(
                name: "ProposedFacilityId",
                table: "DefaultOpeningHours");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 10, 17, 37, 953, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.InsertData(
                table: "SpecialOpeningHours",
                columns: new[] { "Date", "FacilityId", "CloseTime", "OpenTime" },
                values: new object[] { new DateOnly(2024, 4, 11), 1, new TimeOnly(23, 30, 0), new TimeOnly(6, 0, 0) });
        }
    }
}

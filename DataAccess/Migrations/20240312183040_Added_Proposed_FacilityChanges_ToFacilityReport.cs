using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_Proposed_FacilityChanges_ToFacilityReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProposedFacilityChangeId",
                table: "FacilityReports",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedAt", "ProposedFacilityChangeId" },
                values: new object[] { new DateTime(2024, 3, 12, 19, 30, 39, 584, DateTimeKind.Local).AddTicks(7720), null });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "ProposedFacilityChangeId" },
                values: new object[] { new DateTime(2024, 3, 12, 19, 30, 39, 584, DateTimeKind.Local).AddTicks(7690), null });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReports_ProposedFacilityChangeId",
                table: "FacilityReports",
                column: "ProposedFacilityChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityReports_ProposedFacilityChanges_ProposedFacilityChangeId",
                table: "FacilityReports",
                column: "ProposedFacilityChangeId",
                principalTable: "ProposedFacilityChanges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityReports_ProposedFacilityChanges_ProposedFacilityChangeId",
                table: "FacilityReports");

            migrationBuilder.DropIndex(
                name: "IX_FacilityReports_ProposedFacilityChangeId",
                table: "FacilityReports");

            migrationBuilder.DropColumn(
                name: "ProposedFacilityChangeId",
                table: "FacilityReports");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 52, 21, 954, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 52, 21, 954, DateTimeKind.Local).AddTicks(6585));
        }
    }
}

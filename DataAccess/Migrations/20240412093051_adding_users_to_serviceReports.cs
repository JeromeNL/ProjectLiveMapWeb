using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adding_users_to_serviceReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ServiceReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 30, 50, 786, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 30, 50, 786, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 30, 50, 786, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 30, 50, 786, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReports_UserId",
                table: "ServiceReports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReports_Users_UserId",
                table: "ServiceReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReports_Users_UserId",
                table: "ServiceReports");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReports_UserId",
                table: "ServiceReports");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ServiceReports");

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
        }
    }
}

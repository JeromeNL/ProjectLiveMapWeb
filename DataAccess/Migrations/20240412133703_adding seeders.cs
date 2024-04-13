using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingseeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "ServiceReportCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "category 1" },
                    { 2, "category 2" },
                    { 3, "category 3" }
                });

            migrationBuilder.InsertData(
                table: "ServiceReports",
                columns: new[] { "Id", "Description", "FacilityId", "ServiceReportCategoryId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "description1", 1, 1, "report 1", 1 },
                    { 2, "description2", 1, 1, "report 2", 1 },
                    { 3, "description3", 1, 1, "report 3", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(589));
        }
    }
}

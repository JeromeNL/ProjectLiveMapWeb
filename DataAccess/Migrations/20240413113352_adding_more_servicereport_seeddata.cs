using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adding_more_servicereport_seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Onderhoud");

            migrationBuilder.UpdateData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Beveiliging");

            migrationBuilder.UpdateData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Schoonmaak");

            migrationBuilder.InsertData(
                table: "ServiceReportCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Apperatuur storing" },
                    { 5, "Inspectie" },
                    { 6, "Feedback" }
                });

            migrationBuilder.InsertData(
                table: "ServiceReports",
                columns: new[] { "Id", "Description", "FacilityId", "ServiceReportCategoryId", "Title", "UserId" },
                values: new object[,]
                {
                    { 4, "description4", 1, 1, "report 4", 1 },
                    { 5, "description5", 2, 2, "report 5", 2 },
                    { 6, "description6", 3, 3, "report 6", 3 },
                    { 10, "description10", 1, 1, "report 10", 1 },
                    { 11, "description11", 2, 2, "report 11", 2 },
                    { 12, "description12", 3, 3, "report 12", 3 },
                    { 16, "description16", 1, 1, "report 16", 2 },
                    { 17, "description17", 2, 2, "report 17", 3 },
                    { 18, "description18", 3, 3, "report 18", 4 },
                    { 22, "description22", 1, 1, "report 22", 2 },
                    { 23, "description23", 2, 2, "report 23", 3 },
                    { 7, "description7", 1, 4, "report 7", 4 },
                    { 8, "description8", 2, 5, "report 8", 5 },
                    { 9, "description9", 3, 6, "report 9", 6 },
                    { 13, "description13", 1, 4, "report 13", 4 },
                    { 14, "description14", 2, 5, "report 14", 5 },
                    { 15, "description15", 3, 6, "report 15", 6 },
                    { 19, "description19", 1, 4, "report 19", 5 },
                    { 20, "description20", 2, 5, "report 20", 6 },
                    { 21, "description21", 3, 6, "report 21", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ServiceReports",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 28, 12, 739, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 28, 12, 739, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 28, 12, 739, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 12, 28, 12, 739, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "category 1");

            migrationBuilder.UpdateData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "category 2");

            migrationBuilder.UpdateData(
                table: "ServiceReportCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "category 3");
        }
    }
}

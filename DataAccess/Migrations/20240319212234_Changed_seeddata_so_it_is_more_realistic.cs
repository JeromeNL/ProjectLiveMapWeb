using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Changed_seeddata_so_it_is_more_realistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.341722544598902, 5.2455371618270883 });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.343434225015848, 5.2462238073349008 });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 22, 22, 33, 725, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 22, 22, 33, 725, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "ProposedFacilityChanges",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.341722544598902, 5.2455371618270883 });

            migrationBuilder.UpdateData(
                table: "ProposedFacilityChanges",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.343434225015848, 5.2462238073349008 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.688673302068032, 5.284670979381513 });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.688403441591433, 5.2859250150824995 });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 13, 40, 48, 715, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 13, 40, 48, 715, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "ProposedFacilityChanges",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.688673302068032, 5.284670979381513 });

            migrationBuilder.UpdateData(
                table: "ProposedFacilityChanges",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.688403441591433, 5.2859250150824995 });
        }
    }
}

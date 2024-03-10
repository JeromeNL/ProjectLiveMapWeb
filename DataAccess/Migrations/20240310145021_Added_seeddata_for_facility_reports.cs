using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_seeddata_for_facility_reports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FacilityReports",
                columns: new[] { "Id", "Description", "FacilityId" },
                values: new object[,]
                {
                    { -2, "Het zwemmeer is in goede staat.", -2 },
                    { -1, "Het sportveld is in goede staat.", -1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}

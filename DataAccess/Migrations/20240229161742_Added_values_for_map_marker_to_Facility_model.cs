using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_values_for_map_marker_to_Facility_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Facilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Facilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Description", "IconUrl", "Latitude", "Longitude", "Name", "Type" },
                values: new object[,]
                {
                    { -2, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", "https://cdn-icons-png.freepik.com/512/50/50004.png", 51.688673302068032, 5.284670979381513, "Zwemmeer", "Recreatie" },
                    { -1, "Op het sportveld kun je allerlei activiteiten doen. Denk aan voetballen, basketballen en tennissen.", "https://cdn-icons-png.flaticon.com/512/4344/4344985.png", 51.688403441591433, 5.2859250150824995, "Sportveld", "Sport" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Facilities");
        }
    }
}

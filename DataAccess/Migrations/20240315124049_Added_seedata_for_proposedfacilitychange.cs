using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_seedata_for_proposedfacilitychange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityReports_ProposedFacilityChanges_ProposedFacilityChangeId",
                table: "FacilityReports");

            migrationBuilder.AlterColumn<int>(
                name: "ProposedFacilityChangeId",
                table: "FacilityReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedAt", "ProposedFacilityChangeId" },
                values: new object[] { new DateTime(2024, 3, 15, 13, 40, 48, 715, DateTimeKind.Local).AddTicks(8484), -2 });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "ProposedFacilityChangeId" },
                values: new object[] { new DateTime(2024, 3, 15, 13, 40, 48, 715, DateTimeKind.Local).AddTicks(8438), -1 });

            migrationBuilder.InsertData(
                table: "ProposedFacilityChanges",
                columns: new[] { "Id", "Description", "IconUrl", "Latitude", "Longitude", "Name", "Type" },
                values: new object[,]
                {
                    { -2, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", "https://cdn-icons-png.freepik.com/512/50/50004.png", 51.688673302068032, 5.284670979381513, "Zwemmeer JAKDKJLDUIIRUFJK", "Recreatie" },
                    { -1, "Op het sportveld kun je allerlei activiteiten doen. Denk aan voetballen, basketballen en tennissen.", "https://cdn-icons-png.flaticon.com/512/4344/4344985.png", 51.688403441591433, 5.2859250150824995, "Sportveld Hoevelake", "Sport" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityReports_ProposedFacilityChanges_ProposedFacilityChangeId",
                table: "FacilityReports",
                column: "ProposedFacilityChangeId",
                principalTable: "ProposedFacilityChanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityReports_ProposedFacilityChanges_ProposedFacilityChangeId",
                table: "FacilityReports");

            migrationBuilder.DeleteData(
                table: "ProposedFacilityChanges",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "ProposedFacilityChanges",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<int>(
                name: "ProposedFacilityChangeId",
                table: "FacilityReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedAt", "ProposedFacilityChangeId" },
                values: new object[] { new DateTime(2024, 3, 15, 9, 58, 9, 225, DateTimeKind.Local).AddTicks(135), null });

            migrationBuilder.UpdateData(
                table: "FacilityReports",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "ProposedFacilityChangeId" },
                values: new object[] { new DateTime(2024, 3, 15, 9, 58, 9, 225, DateTimeKind.Local).AddTicks(77), null });

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityReports_ProposedFacilityChanges_ProposedFacilityChangeId",
                table: "FacilityReports",
                column: "ProposedFacilityChangeId",
                principalTable: "ProposedFacilityChanges",
                principalColumn: "Id");
        }
    }
}

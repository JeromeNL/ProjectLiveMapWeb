using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class New_Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProposedFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposedFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposedFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DefaultOpeningHours",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    ProposedFacilityId = table.Column<int>(type: "int", nullable: true),
                    OpenTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultOpeningHours", x => new { x.WeekDay, x.FacilityId });
                    table.ForeignKey(
                        name: "FK_DefaultOpeningHours_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultOpeningHours_ProposedFacilities_ProposedFacilityId",
                        column: x => x.ProposedFacilityId,
                        principalTable: "ProposedFacilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacilityReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposedFacilityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityReports_ProposedFacilities_ProposedFacilityId",
                        column: x => x.ProposedFacilityId,
                        principalTable: "ProposedFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOpeningHours",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ProposedFacilityId = table.Column<int>(type: "int", nullable: true),
                    OpenTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOpeningHours", x => new { x.Date, x.FacilityId });
                    table.ForeignKey(
                        name: "FK_SpecialOpeningHours_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialOpeningHours_ProposedFacilities_ProposedFacilityId",
                        column: x => x.ProposedFacilityId,
                        principalTable: "ProposedFacilities",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "DeletedAt", "Description", "IconName", "Latitude", "Longitude", "Name", "Type" },
                values: new object[,]
                {
                    { 1, null, "Restaurant de Kom is een gezellig restaurant", "trash", 51.647970807304127, 5.0468584734210191, "Restaurant de Kom", "Restaurant" },
                    { 2, null, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", "chef-hat", 51.647223135629211, 5.05165372379847, "Zwemmeer", "Recreatie" },
                    { 3, null, "De speeltuin is een leuke plek voor kinderen om te spelen.", "horse-toy", 51.651976894252684, 5.0534545833544868, "Speeltuin", "Recreatie" }
                });

            migrationBuilder.InsertData(
                table: "ProposedFacilities",
                columns: new[] { "Id", "Description", "FacilityId", "IconName", "Latitude", "Longitude", "Name", "Type" },
                values: new object[] { 4, "De nieuwe zwemzee", null, "trash", 51.651976894252684, 5.0534545833544868, "Zwemzee", "Recreatie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Almior" },
                    { 2, "Joram" },
                    { 3, "Thieme" }
                });

            migrationBuilder.InsertData(
                table: "DefaultOpeningHours",
                columns: new[] { "FacilityId", "WeekDay", "CloseTime", "OpenTime", "ProposedFacilityId" },
                values: new object[,]
                {
                    { 1, 0, new TimeOnly(23, 59, 0), new TimeOnly(0, 0, 0), null },
                    { 2, 0, new TimeOnly(23, 59, 0), new TimeOnly(0, 0, 0), null },
                    { 3, 0, new TimeOnly(23, 59, 0), new TimeOnly(0, 0, 0), null },
                    { 1, 1, new TimeOnly(20, 0, 0), new TimeOnly(14, 0, 0), null },
                    { 2, 1, new TimeOnly(20, 0, 0), new TimeOnly(14, 0, 0), null },
                    { 3, 1, new TimeOnly(20, 0, 0), new TimeOnly(14, 0, 0), null },
                    { 1, 2, new TimeOnly(20, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 2, 2, new TimeOnly(20, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 3, 2, new TimeOnly(20, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 1, 3, new TimeOnly(21, 0, 0), new TimeOnly(11, 0, 0), null },
                    { 2, 3, new TimeOnly(21, 0, 0), new TimeOnly(11, 0, 0), null },
                    { 3, 3, new TimeOnly(21, 0, 0), new TimeOnly(11, 0, 0), null },
                    { 1, 4, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 2, 4, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 3, 4, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 1, 5, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 2, 5, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 3, 5, new TimeOnly(21, 0, 0), new TimeOnly(12, 0, 0), null },
                    { 1, 6, new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0), null },
                    { 2, 6, new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0), null },
                    { 3, 6, new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "FacilityReports",
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId" },
                values: new object[] { 4, new DateTime(2024, 4, 15, 11, 1, 56, 294, DateTimeKind.Local).AddTicks(9430), "Seed", 4 });

            migrationBuilder.InsertData(
                table: "ProposedFacilities",
                columns: new[] { "Id", "Description", "FacilityId", "IconName", "Latitude", "Longitude", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Restaurant de Kom is een gezellig restaurant", 1, "trash", 51.647970807304127, 5.0468584734210191, "Restaurant de Kom", "Restaurant" },
                    { 2, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", 2, "chef-hat", 51.647223135629211, 5.05165372379847, "Zwemmeer", "Recreatie" },
                    { 3, "De speeltuin is een leuke plek voor kinderen om te spelen.", 3, "horse-toy", 51.651976894252684, 5.0534545833544868, "Speeltuin", "Recreatie" }
                });

            migrationBuilder.InsertData(
                table: "SpecialOpeningHours",
                columns: new[] { "Date", "FacilityId", "CloseTime", "OpenTime", "ProposedFacilityId" },
                values: new object[,]
                {
                    { new DateOnly(2024, 4, 17), 1, new TimeOnly(23, 30, 0), new TimeOnly(6, 0, 0), null },
                    { new DateOnly(2024, 4, 20), 1, new TimeOnly(14, 0, 0), new TimeOnly(9, 0, 0), null },
                    { new DateOnly(2024, 4, 30), 1, new TimeOnly(22, 0, 0), new TimeOnly(15, 0, 0), null },
                    { new DateOnly(2024, 4, 30), 2, new TimeOnly(22, 0, 0), new TimeOnly(15, 0, 0), null },
                    { new DateOnly(2024, 5, 5), 2, new TimeOnly(22, 0, 0), new TimeOnly(15, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "FacilityReports",
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 11, 1, 56, 294, DateTimeKind.Local).AddTicks(9370), "Seed", 1 },
                    { 2, new DateTime(2024, 4, 15, 11, 1, 56, 294, DateTimeKind.Local).AddTicks(9420), "Seed", 2 },
                    { 3, new DateTime(2024, 4, 15, 11, 1, 56, 294, DateTimeKind.Local).AddTicks(9430), "Seed", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultOpeningHours_FacilityId",
                table: "DefaultOpeningHours",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultOpeningHours_ProposedFacilityId",
                table: "DefaultOpeningHours",
                column: "ProposedFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReports_ProposedFacilityId",
                table: "FacilityReports",
                column: "ProposedFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedFacilities_FacilityId",
                table: "ProposedFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOpeningHours_FacilityId",
                table: "SpecialOpeningHours",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOpeningHours_ProposedFacilityId",
                table: "SpecialOpeningHours",
                column: "ProposedFacilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultOpeningHours");

            migrationBuilder.DropTable(
                name: "FacilityReports");

            migrationBuilder.DropTable(
                name: "SpecialOpeningHours");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProposedFacilities");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}

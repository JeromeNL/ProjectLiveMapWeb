using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "ServiceReportCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReportCategories", x => x.Id);
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
                name: "ServiceReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ServiceReportCategoryId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReports_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceReports_ServiceReportCategories_ServiceReportCategoryId",
                        column: x => x.ServiceReportCategoryId,
                        principalTable: "ServiceReportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 3, "Thieme" },
                    { 4, "Mauro" },
                    { 5, "Imke" },
                    { 6, "Lamine" }
                });

            migrationBuilder.InsertData(
                table: "FacilityReports",
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId" },
                values: new object[] { 4, new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(589), "Seed", 4 });

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
                table: "FacilityReports",
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(529), "Seed", 1 },
                    { 2, new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(586), "Seed", 2 },
                    { 3, new DateTime(2024, 4, 12, 11, 58, 20, 412, DateTimeKind.Local).AddTicks(588), "Seed", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReports_ProposedFacilityId",
                table: "FacilityReports",
                column: "ProposedFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedFacilities_FacilityId",
                table: "ProposedFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReports_FacilityId",
                table: "ServiceReports",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReports_ServiceReportCategoryId",
                table: "ServiceReports",
                column: "ServiceReportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReports_UserId",
                table: "ServiceReports",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityReports");

            migrationBuilder.DropTable(
                name: "ServiceReports");

            migrationBuilder.DropTable(
                name: "ProposedFacilities");

            migrationBuilder.DropTable(
                name: "ServiceReportCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}

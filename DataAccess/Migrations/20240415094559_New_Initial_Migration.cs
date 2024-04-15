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
                name: "FacilityCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityCategories", x => x.Id);
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
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_FacilityCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FacilityCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CategoryId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_ProposedFacilities_FacilityCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FacilityCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceReportCategoryId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_FacilityReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                table: "FacilityCategories",
                columns: new[] { "Id", "DeletedAt", "Description", "IconName", "Name" },
                values: new object[,]
                {
                    { 1, null, "Voorzieningen die eten en drinken mogelijk maken", "chef-hat", "Restaurant" },
                    { 2, null, "Voorzieningen die sport mogelijk maken", "ball-tennis", "Sport" },
                    { 3, null, "Voorzieningen die boodschappen mogelijk maken", "shopping-cart", "Supermarkt" },
                    { 4, null, "Voorzieningen die zwemmen mogelijk maken", "swimming", "Zwembad" }
                });

            migrationBuilder.InsertData(
                table: "ServiceReportCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Onderhoud" },
                    { 2, "Beveiliging" },
                    { 3, "Schoonmaak" },
                    { 4, "Apparatuurstoring" },
                    { 5, "Inspectie" },
                    { 6, "Feedback" }
                });

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
                table: "Facilities",
                columns: new[] { "Id", "CategoryId", "DeletedAt", "Description", "IconName", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Restaurant de Kom is een gezellig restaurant", "smoking", 51.647970807304127, 5.0468584734210191, "Restaurant de Kom" },
                    { 2, 3, null, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", "smoking", 51.647223135629211, 5.05165372379847, "Zwemmeer" },
                    { 3, 1, null, "De speeltuin is een leuke plek voor kinderen om te spelen.", "smoking", 51.651976894252684, 5.0534545833544868, "Speeltuin" }
                });

            migrationBuilder.InsertData(
                table: "ProposedFacilities",
                columns: new[] { "Id", "CategoryId", "Description", "FacilityId", "IconName", "Latitude", "Longitude", "Name" },
                values: new object[] { 4, 1, "De nieuwe zwemzee", null, "smoking", 51.651976894252684, 5.0534545833544868, "Zwemzee" });

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
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId", "UserId" },
                values: new object[] { 4, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1260), "Seed", 4, 1 });

            migrationBuilder.InsertData(
                table: "ProposedFacilities",
                columns: new[] { "Id", "CategoryId", "Description", "FacilityId", "IconName", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Restaurant de Kom is een gezellig restaurant", 1, "smoking", 51.647970807304127, 5.0468584734210191, "Restaurant de Kom" },
                    { 2, 3, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", 2, "smoking", 51.647223135629211, 5.05165372379847, "Zwemmeer" },
                    { 3, 1, "De speeltuin is een leuke plek voor kinderen om te spelen.", 3, "smoking", 51.651976894252684, 5.0534545833544868, "Speeltuin" }
                });

            migrationBuilder.InsertData(
                table: "ServiceReports",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "FacilityId", "ServiceReportCategoryId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1600), null, "description1", 1, 1, "report 1", 1 },
                    { 2, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1610), null, "description2", 1, 1, "report 2", 1 },
                    { 3, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1620), null, "description3", 1, 1, "report 3", 1 },
                    { 4, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1620), null, "description4", 1, 1, "report 4", 1 },
                    { 5, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1620), null, "description5", 2, 2, "report 5", 2 },
                    { 6, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1630), null, "description6", 3, 3, "report 6", 3 },
                    { 7, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1630), null, "description7", 1, 4, "report 7", 4 },
                    { 8, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1640), null, "description8", 2, 5, "report 8", 5 },
                    { 9, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1640), null, "description9", 3, 6, "report 9", 6 },
                    { 10, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1640), null, "description10", 1, 1, "report 10", 1 },
                    { 11, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1640), null, "description11", 2, 2, "report 11", 2 },
                    { 12, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1650), null, "description12", 3, 3, "report 12", 3 },
                    { 13, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1650), null, "description13", 1, 4, "report 13", 4 },
                    { 14, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1650), null, "description14", 2, 5, "report 14", 5 },
                    { 15, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1660), null, "description15", 3, 6, "report 15", 6 },
                    { 16, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1660), null, "description16", 1, 1, "report 16", 2 },
                    { 17, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1660), null, "description17", 2, 2, "report 17", 3 },
                    { 18, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1670), null, "description18", 3, 3, "report 18", 4 },
                    { 19, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1670), null, "description19", 1, 4, "report 19", 5 },
                    { 20, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1740), null, "description20", 2, 5, "report 20", 6 },
                    { 21, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1750), null, "description21", 3, 6, "report 21", 1 },
                    { 22, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1750), null, "description22", 1, 1, "report 22", 2 },
                    { 23, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1750), null, "description23", 2, 2, "report 23", 3 },
                    { 24, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1760), null, "description24", 3, 3, "report 24", 4 },
                    { 25, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1760), null, "description25", 1, 4, "report 25", 5 },
                    { 26, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1760), null, "description26", 2, 5, "report 26", 6 },
                    { 27, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1770), null, "description27", 3, 6, "report 27", 1 },
                    { 28, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1770), null, "description28", 1, 1, "report 28", 2 },
                    { 29, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1770), null, "description29", 2, 2, "report 29", 3 },
                    { 30, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1770), null, "description30", 3, 3, "report 30", 4 }
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
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1220), "Seed", 1, 1 },
                    { 2, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1260), "Seed", 2, 1 },
                    { 3, new DateTime(2024, 4, 15, 11, 45, 59, 46, DateTimeKind.Local).AddTicks(1260), "Seed", 3, 1 }
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
                name: "IX_Facilities_CategoryId",
                table: "Facilities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReports_ProposedFacilityId",
                table: "FacilityReports",
                column: "ProposedFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReports_UserId",
                table: "FacilityReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedFacilities_CategoryId",
                table: "ProposedFacilities",
                column: "CategoryId");

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
                name: "ServiceReports");

            migrationBuilder.DropTable(
                name: "SpecialOpeningHours");

            migrationBuilder.DropTable(
                name: "ServiceReportCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProposedFacilities");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "FacilityCategories");
        }
    }
}

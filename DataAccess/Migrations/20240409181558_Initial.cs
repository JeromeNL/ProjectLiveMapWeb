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
                    Longitude = table.Column<double>(type: "float", nullable: false)
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
                    Longitude = table.Column<double>(type: "float", nullable: false)
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
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Almior" },
                    { 2, "Joram" },
                    { 3, "Thieme" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CategoryId", "DeletedAt", "Description", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Restaurant de Kom is een gezellig restaurant", 51.647970807304127, 5.0468584734210191, "Restaurant de Kom" },
                    { 2, 3, null, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", 51.647223135629211, 5.05165372379847, "Zwemmeer" },
                    { 3, 1, null, "De speeltuin is een leuke plek voor kinderen om te spelen.", 51.651976894252684, 5.0534545833544868, "Speeltuin" }
                });

            migrationBuilder.InsertData(
                table: "ProposedFacilities",
                columns: new[] { "Id", "CategoryId", "Description", "FacilityId", "Latitude", "Longitude", "Name" },
                values: new object[] { 4, 1, "De nieuwe zwemzee", null, 51.651976894252684, 5.0534545833544868, "Zwemzee" });

            migrationBuilder.InsertData(
                table: "FacilityReports",
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId" },
                values: new object[] { 4, new DateTime(2024, 4, 9, 20, 15, 57, 739, DateTimeKind.Local).AddTicks(999), "Seed", 4 });

            migrationBuilder.InsertData(
                table: "ProposedFacilities",
                columns: new[] { "Id", "CategoryId", "Description", "FacilityId", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Restaurant de Kom is een gezellig restaurant", 1, 51.647970807304127, 5.0468584734210191, "Restaurant de Kom" },
                    { 2, 3, "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.", 2, 51.647223135629211, 5.05165372379847, "Zwemmeer" },
                    { 3, 1, "De speeltuin is een leuke plek voor kinderen om te spelen.", 3, 51.651976894252684, 5.0534545833544868, "Speeltuin" }
                });

            migrationBuilder.InsertData(
                table: "FacilityReports",
                columns: new[] { "Id", "CreatedAt", "Description", "ProposedFacilityId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 9, 20, 15, 57, 739, DateTimeKind.Local).AddTicks(939), "Seed", 1 },
                    { 2, new DateTime(2024, 4, 9, 20, 15, 57, 739, DateTimeKind.Local).AddTicks(995), "Seed", 2 },
                    { 3, new DateTime(2024, 4, 9, 20, 15, 57, 739, DateTimeKind.Local).AddTicks(997), "Seed", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_CategoryId",
                table: "Facilities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReports_ProposedFacilityId",
                table: "FacilityReports",
                column: "ProposedFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedFacilities_CategoryId",
                table: "ProposedFacilities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedFacilities_FacilityId",
                table: "ProposedFacilities",
                column: "FacilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityReports");

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

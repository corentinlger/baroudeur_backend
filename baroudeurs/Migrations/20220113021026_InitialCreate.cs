using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baroudeurs.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    AccountCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastConnection = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsOnline = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointOfInterest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsEssential = table.Column<bool>(type: "INTEGER", nullable: false),
                    Theme = table.Column<int>(type: "INTEGER", nullable: false),
                    PointType = table.Column<int>(type: "INTEGER", nullable: false),
                    Latitude = table.Column<string>(type: "TEXT", nullable: true),
                    Longitude = table.Column<string>(type: "TEXT", nullable: true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfInterest_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discovery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PointId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeOfDiscovery = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discovery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discovery_PointOfInterest_PointId",
                        column: x => x.PointId,
                        principalTable: "PointOfInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discovery_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discovery_PointId",
                table: "Discovery",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Discovery_UserId",
                table: "Discovery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterest_CityId",
                table: "PointOfInterest",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discovery");

            migrationBuilder.DropTable(
                name: "PointOfInterest");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppWeather.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RuName = table.Column<string>(type: "TEXT", nullable: false),
                    EnName = table.Column<string>(type: "TEXT", nullable: true),
                    Lon = table.Column<decimal>(type: "TEXT", nullable: false),
                    Lat = table.Column<decimal>(type: "TEXT", nullable: false),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    RuName = table.Column<string>(type: "TEXT", nullable: false),
                    EnName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RuName = table.Column<string>(type: "TEXT", nullable: false),
                    EnName = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "EnName", "Lat", "Lon", "RegionId", "RuName" },
                values: new object[] { 498817, "Saint Petersburg", 59.89444400m, 30.26416800m, 2, "Санкт-Петербруг" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "EnName", "Lat", "Lon", "RegionId", "RuName" },
                values: new object[] { 524894, "Moscow", 55.76166500m, 37.60666700m, 1, "Москва" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "EnName", "Lat", "Lon", "RegionId", "RuName" },
                values: new object[] { 1486209, "Yekaterinburg", 56.85749800m, 60.61249900m, 3, "Екатеринбург" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "EnName", "Lat", "Lon", "RegionId", "RuName" },
                values: new object[] { 1496747, "Novosibirsk", 55.04111100m, 82.93444100m, 5, "Новосибирск" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "EnName", "Lat", "Lon", "RegionId", "RuName" },
                values: new object[] { 2013348, "Vladivostok", 43.10562100m, 131.87353500m, 4, "Владивосток" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "EnName", "RuName" },
                values: new object[] { "RU", "Russia", "Россия" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CountryId", "EnName", "RuName" },
                values: new object[] { 1, "RU", "Moscow Oblast", "Московская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CountryId", "EnName", "RuName" },
                values: new object[] { 2, "RU", "Leninskaya Oblast", "Ленинградская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CountryId", "EnName", "RuName" },
                values: new object[] { 3, "RU", "Sverdlovsk Oblast", "Свердловская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CountryId", "EnName", "RuName" },
                values: new object[] { 4, "RU", "Primorsky Krai", "Приморский край" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CountryId", "EnName", "RuName" },
                values: new object[] { 5, "RU", "Novosibirskaya Oblast", "Новосибирская область" });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                table: "Regions",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

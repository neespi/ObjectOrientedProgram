using Microsoft.EntityFrameworkCore.Migrations;

namespace Bridges.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BridgesPoints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CrossRiver = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BridgesPoints", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BridgesPoints",
                columns: new[] { "Id", "CrossRiver", "Location", "Name", "Year" },
                values: new object[] { 1L, "пруд в парке стадиона Красная Пресня", "Дружинниковская улица", "Мост пешеходный «1905 года»", "1981" });

            migrationBuilder.InsertData(
                table: "BridgesPoints",
                columns: new[] { "Id", "CrossRiver", "Location", "Name", "Year" },
                values: new object[] { 2L, "река Москва", "1-я Фрунзенская улица", "Мост пешеходный «Андреевский»", "2000" });

            migrationBuilder.InsertData(
                table: "BridgesPoints",
                columns: new[] { "Id", "CrossRiver", "Location", "Name", "Year" },
                values: new object[] { 3L, "река Сетунь", "улица Пырьева, дом 24", "Мост пешеходный «Балочный»", "1956" });

            migrationBuilder.InsertData(
                table: "BridgesPoints",
                columns: new[] { "Id", "CrossRiver", "Location", "Name", "Year" },
                values: new object[] { 4L, "пруд Серебряно-Виноградный", "городок имени Баумана", "Мост пешеходный «Бауманский-1»", "1964" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BridgesPoints");
        }
    }
}

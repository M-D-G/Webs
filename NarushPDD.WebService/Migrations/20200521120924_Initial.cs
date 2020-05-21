using Microsoft.EntityFrameworkCore.Migrations;

namespace NarushPDD.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoadPDDs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<string>(nullable: true),
                    RecordedV = table.Column<string>(nullable: true),
                    RegisteredV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadPDDs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RoadPDDs",
                columns: new[] { "Id", "Data", "RecordedV", "RegisteredV" },
                values: new object[] { 1L, "20.01.2013", "Общее количество зафиксированных нарушений - 5374", "Общее количество оформленных - 2440" });

            migrationBuilder.InsertData(
                table: "RoadPDDs",
                columns: new[] { "Id", "Data", "RecordedV", "RegisteredV" },
                values: new object[] { 2L, "21.01.2013", "Общее количество зафиксированных нарушений - 25312", "Общее количество оформленных - 1551" });

            migrationBuilder.InsertData(
                table: "RoadPDDs",
                columns: new[] { "Id", "Data", "RecordedV", "RegisteredV" },
                values: new object[] { 3L, "22.01.2013", "Общее количество зафиксированных нарушений - 29132", "Общее количество оформленных - 2672" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoadPDDs");
        }
    }
}

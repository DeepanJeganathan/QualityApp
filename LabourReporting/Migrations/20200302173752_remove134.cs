using Microsoft.EntityFrameworkCore.Migrations;

namespace LabourReporting.Migrations
{
    public partial class remove134 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkStations",
                keyColumn: "WorkStationId",
                keyValue: 134);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkStations",
                columns: new[] { "WorkStationId", "Department", "WorkStationName" },
                values: new object[] { 134, 2, "Myrtle" });
        }
    }
}

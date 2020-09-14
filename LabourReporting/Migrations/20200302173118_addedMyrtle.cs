using Microsoft.EntityFrameworkCore.Migrations;

namespace LabourReporting.Migrations
{
    public partial class addedMyrtle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkStations",
                columns: new[] { "WorkStationId", "Department", "WorkStationName" },
                values: new object[] { 134, 2, "Myrtle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkStations",
                keyColumn: "WorkStationId",
                keyValue: 134);
        }
    }
}

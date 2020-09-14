using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabourReporting.Migrations
{
    public partial class LengthVarianceModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LengthVariances",
                columns: table => new
                {
                    LengthVarianceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Item = table.Column<string>(nullable: false),
                    Qty = table.Column<double>(nullable: false),
                    UOM = table.Column<string>(nullable: true),
                    Order_number = table.Column<int>(nullable: true),
                    LotNo = table.Column<double>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    Cell = table.Column<int>(nullable: false),
                    DefectCode = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    WorkStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LengthVariances", x => x.LengthVarianceID);
                    table.ForeignKey(
                        name: "FK_LengthVariances_WorkStations_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LengthVariances_WorkStationId",
                table: "LengthVariances",
                column: "WorkStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LengthVariances");
        }
    }
}

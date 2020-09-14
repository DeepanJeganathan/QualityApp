using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabourReporting.Migrations
{
    public partial class ftBrakeDown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FtBreakdowns",
                columns: table => new
                {
                    FtBreakdownId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ncr_No = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    RootCause = table.Column<string>(nullable: true),
                    SecondLevel = table.Column<string>(nullable: true),
                    Compound = table.Column<string>(nullable: true),
                    AWGSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FtBreakdowns", x => x.FtBreakdownId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FtBreakdowns");
        }
    }
}

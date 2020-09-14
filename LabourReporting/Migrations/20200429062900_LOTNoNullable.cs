using Microsoft.EntityFrameworkCore.Migrations;

namespace LabourReporting.Migrations
{
    public partial class LOTNoNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LotNo",
                table: "LengthVariances",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LotNo",
                table: "LengthVariances",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}

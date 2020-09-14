using Microsoft.EntityFrameworkCore.Migrations;

namespace LabourReporting.Migrations
{
    public partial class addedNulltoOperator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NcrTags_Operators_OperatorId",
                table: "NcrTags");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "NcrTags",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_NcrTags_Operators_OperatorId",
                table: "NcrTags",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NcrTags_Operators_OperatorId",
                table: "NcrTags");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "NcrTags",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NcrTags_Operators_OperatorId",
                table: "NcrTags",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

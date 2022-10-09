using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PERMITASSSESSMENT_API.Migrations
{
    public partial class addfee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeeID",
                table: "Assessment_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_Details_FeeID",
                table: "Assessment_Details",
                column: "FeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessment_Details_Fees_FeeID",
                table: "Assessment_Details",
                column: "FeeID",
                principalTable: "Fees",
                principalColumn: "FeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessment_Details_Fees_FeeID",
                table: "Assessment_Details");

            migrationBuilder.DropIndex(
                name: "IX_Assessment_Details_FeeID",
                table: "Assessment_Details");

            migrationBuilder.DropColumn(
                name: "FeeID",
                table: "Assessment_Details");
        }
    }
}

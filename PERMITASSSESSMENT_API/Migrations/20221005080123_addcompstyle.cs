using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PERMITASSSESSMENT_API.Migrations
{
    public partial class addcompstyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompStyleID",
                table: "FeeComputations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeeComputations_CompStyleID",
                table: "FeeComputations",
                column: "CompStyleID");

            migrationBuilder.AddForeignKey(
                name: "FK_FeeComputations_ComputationStyles_CompStyleID",
                table: "FeeComputations",
                column: "CompStyleID",
                principalTable: "ComputationStyles",
                principalColumn: "CompStyleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeeComputations_ComputationStyles_CompStyleID",
                table: "FeeComputations");

            migrationBuilder.DropIndex(
                name: "IX_FeeComputations_CompStyleID",
                table: "FeeComputations");

            migrationBuilder.DropColumn(
                name: "CompStyleID",
                table: "FeeComputations");
        }
    }
}

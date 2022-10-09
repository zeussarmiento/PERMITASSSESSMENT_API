using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PERMITASSSESSMENT_API.Migrations
{
    public partial class changespelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpperBracker",
                table: "FeeComputations",
                newName: "UpperBracket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpperBracket",
                table: "FeeComputations",
                newName: "UpperBracker");
        }
    }
}

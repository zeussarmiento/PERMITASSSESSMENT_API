using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PERMITASSSESSMENT_API.Migrations
{
    public partial class addamounttofees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "FeeComputations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "FeeComputations");
        }
    }
}

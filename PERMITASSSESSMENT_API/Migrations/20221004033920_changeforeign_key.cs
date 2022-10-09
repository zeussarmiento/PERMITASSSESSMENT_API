using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PERMITASSSESSMENT_API.Migrations
{
    public partial class changeforeign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessment_Details_OPFeeReferences_OPFeeReferenceReferenceID",
                table: "Assessment_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_PermitTypes_PermitTypePtypeID",
                table: "Fees");

            migrationBuilder.DropIndex(
                name: "IX_Assessment_Details_OPFeeReferenceReferenceID",
                table: "Assessment_Details");

            migrationBuilder.DropColumn(
                name: "PType",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "CatID",
                table: "FeeComputations");

            migrationBuilder.DropColumn(
                name: "OPFeeReferenceReferenceID",
                table: "Assessment_Details");

            migrationBuilder.RenameColumn(
                name: "PermitTypePtypeID",
                table: "Fees",
                newName: "PtypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Fees_PermitTypePtypeID",
                table: "Fees",
                newName: "IX_Fees_PtypeID");

            migrationBuilder.RenameColumn(
                name: "RefID",
                table: "Assessment_Details",
                newName: "ReferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_Details_ReferenceID",
                table: "Assessment_Details",
                column: "ReferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessment_Details_OPFeeReferences_ReferenceID",
                table: "Assessment_Details",
                column: "ReferenceID",
                principalTable: "OPFeeReferences",
                principalColumn: "ReferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_PermitTypes_PtypeID",
                table: "Fees",
                column: "PtypeID",
                principalTable: "PermitTypes",
                principalColumn: "PtypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessment_Details_OPFeeReferences_ReferenceID",
                table: "Assessment_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_PermitTypes_PtypeID",
                table: "Fees");

            migrationBuilder.DropIndex(
                name: "IX_Assessment_Details_ReferenceID",
                table: "Assessment_Details");

            migrationBuilder.RenameColumn(
                name: "PtypeID",
                table: "Fees",
                newName: "PermitTypePtypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Fees_PtypeID",
                table: "Fees",
                newName: "IX_Fees_PermitTypePtypeID");

            migrationBuilder.RenameColumn(
                name: "ReferenceID",
                table: "Assessment_Details",
                newName: "RefID");

            migrationBuilder.AddColumn<int>(
                name: "PType",
                table: "Fees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatID",
                table: "FeeComputations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OPFeeReferenceReferenceID",
                table: "Assessment_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_Details_OPFeeReferenceReferenceID",
                table: "Assessment_Details",
                column: "OPFeeReferenceReferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessment_Details_OPFeeReferences_OPFeeReferenceReferenceID",
                table: "Assessment_Details",
                column: "OPFeeReferenceReferenceID",
                principalTable: "OPFeeReferences",
                principalColumn: "ReferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_PermitTypes_PermitTypePtypeID",
                table: "Fees",
                column: "PermitTypePtypeID",
                principalTable: "PermitTypes",
                principalColumn: "PtypeID");
        }
    }
}

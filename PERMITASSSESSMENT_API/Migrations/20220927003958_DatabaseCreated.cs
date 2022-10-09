using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PERMITASSSESSMENT_API.Migrations
{
    public partial class DatabaseCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ComputationStyles",
                columns: table => new
                {
                    CompStyleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputationStyles", x => x.CompStyleID);
                });

            migrationBuilder.CreateTable(
                name: "OPFeeReferences",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubsidiaryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DboCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CtrlCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fund = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundSubgroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeSubgroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeObject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlgfCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeSubdesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPFeeReferences", x => x.ReferenceID);
                });

            migrationBuilder.CreateTable(
                name: "PermitTypes",
                columns: table => new
                {
                    PtypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitTypes", x => x.PtypeID);
                });

            migrationBuilder.CreateTable(
                name: "Assessment_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessedFees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DateAssessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Assessed_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control_Num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefID = table.Column<int>(type: "int", nullable: true),
                    OPFeeReferenceReferenceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessment_Details_OPFeeReferences_OPFeeReferenceReferenceID",
                        column: x => x.OPFeeReferenceReferenceID,
                        principalTable: "OPFeeReferences",
                        principalColumn: "ReferenceID");
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    FeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: true),
                    PType = table.Column<int>(type: "int", nullable: true),
                    PermitTypePtypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.FeeID);
                    table.ForeignKey(
                        name: "FK_Fees_PermitTypes_PermitTypePtypeID",
                        column: x => x.PermitTypePtypeID,
                        principalTable: "PermitTypes",
                        principalColumn: "PtypeID");
                });

            migrationBuilder.CreateTable(
                name: "FeeComputations",
                columns: table => new
                {
                    FeeComputationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpperBracker = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowerBracket = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Excess = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AdditionalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    FeeID = table.Column<int>(type: "int", nullable: true),
                    CatID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeComputations", x => x.FeeComputationID);
                    table.ForeignKey(
                        name: "FK_FeeComputations_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_FeeComputations_Fees_FeeID",
                        column: x => x.FeeID,
                        principalTable: "Fees",
                        principalColumn: "FeeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_Details_OPFeeReferenceReferenceID",
                table: "Assessment_Details",
                column: "OPFeeReferenceReferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_FeeComputations_CategoryID",
                table: "FeeComputations",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FeeComputations_FeeID",
                table: "FeeComputations",
                column: "FeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_PermitTypePtypeID",
                table: "Fees",
                column: "PermitTypePtypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessment_Details");

            migrationBuilder.DropTable(
                name: "ComputationStyles");

            migrationBuilder.DropTable(
                name: "FeeComputations");

            migrationBuilder.DropTable(
                name: "OPFeeReferences");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "PermitTypes");
        }
    }
}

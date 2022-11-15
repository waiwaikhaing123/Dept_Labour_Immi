using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dept_Labour_Immi.Migrations
{
    public partial class WorktypeAndOperationone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "opearationOne",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentCompleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: true),
                    ThaiCompanyID = table.Column<int>(type: "int", nullable: true),
                    DOEID = table.Column<int>(type: "int", nullable: true),
                    WorkTypeID = table.Column<int>(type: "int", nullable: false),
                    NoOfMaleWorker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfFemaleWorker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNoOfWorker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opearationOne", x => x.ID);
                    table.ForeignKey(
                        name: "FK_opearationOne_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_opearationOne_thaiCompanies_ThaiCompanyID",
                        column: x => x.ThaiCompanyID,
                        principalTable: "thaiCompanies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WorkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DemandType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpearationOneID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkType_opearationOne_OpearationOneID",
                        column: x => x.OpearationOneID,
                        principalTable: "opearationOne",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_opearationOne_AgencyID",
                table: "opearationOne",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_opearationOne_ThaiCompanyID",
                table: "opearationOne",
                column: "ThaiCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_opearationOne_WorkTypeID",
                table: "opearationOne",
                column: "WorkTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkType_OpearationOneID",
                table: "WorkType",
                column: "OpearationOneID");

            migrationBuilder.AddForeignKey(
                name: "FK_opearationOne_WorkType_WorkTypeID",
                table: "opearationOne",
                column: "WorkTypeID",
                principalTable: "WorkType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opearationOne_WorkType_WorkTypeID",
                table: "opearationOne");

            migrationBuilder.DropTable(
                name: "WorkType");

            migrationBuilder.DropTable(
                name: "opearationOne");
        }
    }
}

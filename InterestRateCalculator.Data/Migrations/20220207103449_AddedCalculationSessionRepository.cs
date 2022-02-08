using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestRateCalculator.DataProvider.Migrations
{
    public partial class AddedCalculationSessionRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("0b810e21-f8fc-4dd9-8a97-774caee0504f"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("75e23f72-a95a-4bf1-9350-4dc3824aa648"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("e17f70c3-2f33-473e-ae25-724a0a26fa01"));

            migrationBuilder.CreateTable(
                name: "CalculationSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationSession_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalculationResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CurrentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FutureValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationResult_CalculationSession_SessionId",
                        column: x => x.SessionId,
                        principalTable: "CalculationSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("b447343d-5cb6-45d4-8adc-4e7776e4f89e"), "INTEREST_LOWER_BOUND", 0.1m });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("3b6bdc27-65c1-45e2-aae5-b667adb485c6"), "INTEREST_UPPER_BOUND", 0.5m });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("c59027ba-e37c-4dab-a091-ced889606bf8"), "INTEREST_INCREMENTAL", 0.2m });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationResult_SessionId",
                table: "CalculationResult",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculationSession_UserId",
                table: "CalculationSession",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationResult");

            migrationBuilder.DropTable(
                name: "CalculationSession");

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("3b6bdc27-65c1-45e2-aae5-b667adb485c6"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("b447343d-5cb6-45d4-8adc-4e7776e4f89e"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("c59027ba-e37c-4dab-a091-ced889606bf8"));

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("75e23f72-a95a-4bf1-9350-4dc3824aa648"), "INTEREST_LOWER_BOUND", 0.1m });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("e17f70c3-2f33-473e-ae25-724a0a26fa01"), "INTEREST_UPPER_BOUND", 0.5m });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("0b810e21-f8fc-4dd9-8a97-774caee0504f"), "INTEREST_INCREMENTAL", 0.2m });
        }
    }
}

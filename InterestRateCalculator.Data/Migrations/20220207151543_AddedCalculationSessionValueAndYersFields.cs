using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestRateCalculator.DataProvider.Migrations
{
    public partial class AddedCalculationSessionValueAndYersFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "CalculationSession",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Years",
                table: "CalculationSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("8cc28321-4168-486c-9af6-5e4ce49812cf"), "INTEREST_LOWER_BOUND", 0.1m });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("6ba08a81-3549-4827-a84e-94216077a0eb"), "INTEREST_UPPER_BOUND", 0.5m });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("53b190ce-ca14-496e-864b-156cd8347f3b"), "INTEREST_INCREMENTAL", 0.2m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("53b190ce-ca14-496e-864b-156cd8347f3b"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("6ba08a81-3549-4827-a84e-94216077a0eb"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("8cc28321-4168-486c-9af6-5e4ce49812cf"));

            migrationBuilder.DropColumn(
                name: "Value",
                table: "CalculationSession");

            migrationBuilder.DropColumn(
                name: "Years",
                table: "CalculationSession");

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
        }
    }
}

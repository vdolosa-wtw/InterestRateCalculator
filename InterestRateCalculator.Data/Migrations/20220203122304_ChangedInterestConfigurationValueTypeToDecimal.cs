using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestRateCalculator.DataProvider.Migrations
{
    public partial class ChangedInterestConfigurationValueTypeToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("628e5164-d718-4cd5-b49c-ebaf616b88d0"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("6906b351-077a-4908-b56d-8e58bed1010f"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("ac3c3163-1a46-42a8-848f-20e461cc8f27"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "InterestConfiguration",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "InterestConfiguration",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("ac3c3163-1a46-42a8-848f-20e461cc8f27"), "INTEREST_LOWER_BOUND", 0.10000000000000001 });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("6906b351-077a-4908-b56d-8e58bed1010f"), "INTEREST_UPPER_BOUND", 0.5 });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("628e5164-d718-4cd5-b49c-ebaf616b88d0"), "INTEREST_INCREMENTAL", 0.20000000000000001 });
        }
    }
}

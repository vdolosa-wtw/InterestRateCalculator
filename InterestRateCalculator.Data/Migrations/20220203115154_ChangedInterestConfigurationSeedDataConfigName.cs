using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestRateCalculator.DataProvider.Migrations
{
    public partial class ChangedInterestConfigurationSeedDataConfigName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("2879ef4c-542b-4af1-a04e-27cb85112ac0"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("42651b1f-c005-472c-92ce-8e88e0d0bc39"));

            migrationBuilder.DeleteData(
                table: "InterestConfiguration",
                keyColumn: "Id",
                keyValue: new Guid("b99b31d3-ac6b-4cf1-a808-62024bdcf14b"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("2879ef4c-542b-4af1-a04e-27cb85112ac0"), "DEFAULT_INTEREST_LOWER", 0.10000000000000001 });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("42651b1f-c005-472c-92ce-8e88e0d0bc39"), "DEFAULT_INTEREST_UPPER", 0.5 });

            migrationBuilder.InsertData(
                table: "InterestConfiguration",
                columns: new[] { "Id", "ConfigName", "Value" },
                values: new object[] { new Guid("b99b31d3-ac6b-4cf1-a808-62024bdcf14b"), "DEFAULT_INTEREST_INCREMENTAL", 0.20000000000000001 });
        }
    }
}

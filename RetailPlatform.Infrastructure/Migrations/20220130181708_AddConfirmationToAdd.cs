using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class AddConfirmationToAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Adds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRefusal",
                table: "Adds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 30, 19, 17, 8, 98, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 30, 19, 17, 8, 101, DateTimeKind.Local).AddTicks(60));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "ReasonForRefusal",
                table: "Adds");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 26, 18, 17, 7, 269, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 26, 18, 17, 7, 275, DateTimeKind.Local).AddTicks(2417));
        }
    }
}

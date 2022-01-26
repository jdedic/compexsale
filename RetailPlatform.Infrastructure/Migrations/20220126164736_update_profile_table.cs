using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class update_profile_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Profiles",
                newName: "FullName");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 26, 17, 47, 35, 710, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 26, 17, 47, 35, 712, DateTimeKind.Local).AddTicks(8918));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Profiles",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 28, 1, 3, 42, 35, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 28, 1, 3, 42, 43, DateTimeKind.Local).AddTicks(731));
        }
    }
}

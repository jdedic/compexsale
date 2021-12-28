using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class AddProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePaths",
                table: "Adds",
                newName: "ImgUrl4");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl1",
                table: "Adds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl2",
                table: "Adds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl3",
                table: "Adds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 27, 23, 18, 43, 642, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 27, 23, 18, 43, 645, DateTimeKind.Local).AddTicks(3304));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl1",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "ImgUrl2",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "ImgUrl3",
                table: "Adds");

            migrationBuilder.RenameColumn(
                name: "ImgUrl4",
                table: "Adds",
                newName: "ImagePaths");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 27, 16, 1, 20, 169, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 27, 16, 1, 20, 174, DateTimeKind.Local).AddTicks(5962));
        }
    }
}

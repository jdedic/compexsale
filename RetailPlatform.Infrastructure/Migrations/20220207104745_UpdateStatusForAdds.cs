using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class UpdateStatusForAdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSale",
                table: "Adds",
                newName: "IsDiscontSale");

            migrationBuilder.RenameColumn(
                name: "IsPurchase",
                table: "Adds",
                newName: "IsComepnsation");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 7, 11, 47, 45, 268, DateTimeKind.Local).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 7, 11, 47, 45, 272, DateTimeKind.Local).AddTicks(299));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDiscontSale",
                table: "Adds",
                newName: "IsSale");

            migrationBuilder.RenameColumn(
                name: "IsComepnsation",
                table: "Adds",
                newName: "IsPurchase");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 5, 9, 45, 27, 667, DateTimeKind.Local).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 5, 9, 45, 27, 671, DateTimeKind.Local).AddTicks(7031));
        }
    }
}

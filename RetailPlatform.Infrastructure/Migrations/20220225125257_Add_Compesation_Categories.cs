using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class Add_Compesation_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.AddColumn<long>(
                name: "SubCategoryId1",
                table: "Adds",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubCategoryId2",
                table: "Adds",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubCategoryId3",
                table: "Adds",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9L, "pal (paleta)" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 25, 13, 52, 56, 799, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 25, 13, 52, 56, 802, DateTimeKind.Local).AddTicks(4847));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DropColumn(
                name: "SubCategoryId1",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "SubCategoryId2",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "SubCategoryId3",
                table: "Adds");

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8L, "pal (paleta)" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 23, 22, 21, 12, 699, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 23, 22, 21, 12, 706, DateTimeKind.Local).AddTicks(2666));
        }
    }
}

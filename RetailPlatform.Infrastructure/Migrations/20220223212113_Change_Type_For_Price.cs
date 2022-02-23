using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class Change_Type_For_Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Adds",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Adds",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 19, 9, 22, 43, 791, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 19, 9, 22, 43, 795, DateTimeKind.Local).AddTicks(4331));
        }
    }
}

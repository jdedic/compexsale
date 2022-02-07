using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class AddUnitType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AgreeWithTersmAndConditions",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExchange",
                table: "Adds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchase",
                table: "Adds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSale",
                table: "Adds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UnitTypeId",
                table: "Adds",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "komad" },
                    { 2L, "m" },
                    { 3L, "m²" },
                    { 4L, "m3" },
                    { 5L, "t" },
                    { 6L, "l" },
                    { 7L, "kg" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 4, 20, 22, 23, 241, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 4, 20, 22, 23, 244, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.CreateIndex(
                name: "IX_Adds_UnitTypeId",
                table: "Adds",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adds_UnitTypes_UnitTypeId",
                table: "Adds",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adds_UnitTypes_UnitTypeId",
                table: "Adds");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropIndex(
                name: "IX_Adds_UnitTypeId",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "AgreeWithTersmAndConditions",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IsExchange",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "IsPurchase",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "IsSale",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "Adds");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 29, 13, 20, 43, 190, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 1, 29, 13, 20, 43, 194, DateTimeKind.Local).AddTicks(6118));
        }
    }
}

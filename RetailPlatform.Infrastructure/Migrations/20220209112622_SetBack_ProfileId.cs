using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class SetBack_ProfileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 9, 12, 26, 21, 901, DateTimeKind.Local).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 9, 12, 26, 21, 904, DateTimeKind.Local).AddTicks(6782));

            migrationBuilder.CreateIndex(
                name: "IX_Adds_ProfileId",
                table: "Adds",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adds_Profiles_ProfileId",
                table: "Adds",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adds_Profiles_ProfileId",
                table: "Adds");

            migrationBuilder.DropIndex(
                name: "IX_Adds_ProfileId",
                table: "Adds");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 9, 12, 18, 25, 518, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 9, 12, 18, 25, 522, DateTimeKind.Local).AddTicks(4739));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class Remove_JobType_From_Add_Tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adds_JobTypes_JobTypeId",
                table: "Adds");

            migrationBuilder.DropIndex(
                name: "IX_Adds_JobTypeId",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "Adds");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 9, 11, 29, 45, 706, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 9, 11, 29, 45, 713, DateTimeKind.Local).AddTicks(2776));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "JobTypeId",
                table: "Adds",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 8, 20, 21, 55, 429, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 8, 20, 21, 55, 432, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.CreateIndex(
                name: "IX_Adds_JobTypeId",
                table: "Adds",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adds_JobTypes_JobTypeId",
                table: "Adds",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

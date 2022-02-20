using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class Add_JobType_To_Adds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2022, 2, 19, 9, 22, 43, 791, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 19, 9, 22, 43, 795, DateTimeKind.Local).AddTicks(4331));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2022, 2, 17, 12, 41, 13, 6, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 17, 12, 41, 13, 10, DateTimeKind.Local).AddTicks(8731));
        }
    }
}

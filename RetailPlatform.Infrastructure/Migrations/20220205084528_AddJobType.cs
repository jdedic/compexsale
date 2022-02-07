using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class AddJobType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "JobTypeId",
                table: "Adds",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Ponuda" },
                    { 2L, "Tražnja" }
                });

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

            migrationBuilder.DropTable(
                name: "JobTypes");

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
                value: new DateTime(2022, 2, 4, 20, 22, 23, 241, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 4, 20, 22, 23, 244, DateTimeKind.Local).AddTicks(1113));
        }
    }
}

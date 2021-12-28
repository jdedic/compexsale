using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class Add_SubCategory_To_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adds_Categories_CategoryId",
                table: "Adds");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Adds",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Adds_CategoryId",
                table: "Adds",
                newName: "IX_Adds_SubCategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Adds_SubCategories_SubCategoryId",
                table: "Adds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adds_SubCategories_SubCategoryId",
                table: "Adds");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Adds",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Adds_SubCategoryId",
                table: "Adds",
                newName: "IX_Adds_CategoryId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 27, 23, 8, 58, 200, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "RegistrationDate",
                value: new DateTime(2021, 12, 27, 23, 8, 58, 203, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.AddForeignKey(
                name: "FK_Adds_Categories_CategoryId",
                table: "Adds",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

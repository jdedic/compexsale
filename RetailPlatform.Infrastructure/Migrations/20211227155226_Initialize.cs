using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailPlatform.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalEntity = table.Column<bool>(type: "bit", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVendor = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ImagePaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adds_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adds_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileCategories_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForgotPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    WorkingPosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorySubCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SubCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategorySubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySubCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Poljoprivreda" },
                    { 2L, "Nekretnine" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Administrator" },
                    { 2L, "Controller" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 21L, "Sportska oprema i rekviziti" },
                    { 20L, "Aksesoari" },
                    { 19L, "Bebi oprema i dečije stvari" },
                    { 18L, "Hemijski proizvodi" },
                    { 17L, "Nameštaj" },
                    { 16L, "Odeća, obuća i tekstil" },
                    { 15L, "Električne mašine i alati" },
                    { 14L, "Mobilni uređaji, tehnika (aparati i uređaji)" },
                    { 13L, "Kancelarijske mašine" },
                    { 12L, "Razni proizvodi i oprema" },
                    { 10L, "Plovni objekti i sredstva" },
                    { 22L, "Umetnost i razonoda" },
                    { 9L, "Vozila" },
                    { 8L, "Oprema i alati" },
                    { 7L, "Mašine" },
                    { 6L, "Nekretnine" },
                    { 5L, "Građevinarstvo" },
                    { 4L, "Rudarstvo" },
                    { 3L, "Prehrambeni proizvodi" },
                    { 2L, "Životinje" },
                    { 1L, "Poljoprivreda i šumarstvo" },
                    { 11L, "Goriva" },
                    { 23L, "Obrazovanje" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Address", "City", "Email", "FirstName", "ForgotPasswordToken", "LastName", "Password", "RegistrationDate", "RoleId", "Telephone", "WorkingPosition", "ZipCode" },
                values: new object[] { 1L, true, "Augusta Cesarca 17", "Novi Sad", "jovanna.deddic@gmail.com", "Jovana", null, "Dedic", "$2a$12$mSRDmGVv.FFskW4e8XD1eehfSBYFcilJmeHiQeKqpIZ786QmYB0GO", new DateTime(2021, 12, 27, 16, 52, 25, 547, DateTimeKind.Local).AddTicks(6144), 1L, "069 5485 156", "Business Manager", "21000" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Address", "City", "Email", "FirstName", "ForgotPasswordToken", "LastName", "Password", "RegistrationDate", "RoleId", "Telephone", "WorkingPosition", "ZipCode" },
                values: new object[] { 2L, true, "Radnicka 8", "Novi Sad", "marko.jankovic@gmail.test", "Marko", null, "Jankovic", "$2a$12$mSRDmGVv.FFskW4e8XD1eehfSBYFcilJmeHiQeKqpIZ786QmYB0GO", new DateTime(2021, 12, 27, 16, 52, 25, 550, DateTimeKind.Local).AddTicks(4359), 2L, "069 5485 156", "Business Manager", "21000" });

            migrationBuilder.CreateIndex(
                name: "IX_Adds_CategoryId",
                table: "Adds",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Adds_ProfileId",
                table: "Adds",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubCategories_CategoryId",
                table: "CategorySubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubCategories_SubCategoryId",
                table: "CategorySubCategories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileCategories_CategoryId",
                table: "ProfileCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileCategories_ProfileId",
                table: "ProfileCategories",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adds");

            migrationBuilder.DropTable(
                name: "CategorySubCategories");

            migrationBuilder.DropTable(
                name: "ProfileCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

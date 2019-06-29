using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerCare.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 9, nullable: true),
                    Country = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SystemRole = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            // Add Seed Data
            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "John", "Smith", "jsmith@gmail.com", new DateTime(1977, 08, 07), "77459", 231, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "James", "Smith", "jamessmith@gmail.com", new DateTime(1979, 05, 03), "77459", 231, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Jimmy", "Smith", "jimmysmith@gmail.com", new DateTime(1981, 01, 21), "77459", 231, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Christopher", "Smith", "chrissmith@gmail.com", new DateTime(2015, 03, 07), "77459", 231, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Adam", "West", "darkknight@gmail.com", new DateTime(1963, 02, 28), "77459", 44, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Jane", "McGray", "jgray@gmail.com", new DateTime(1950, 02, 05), "85040", 1, DateTime.UtcNow, 2 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Julie", "Moore", "jmoore@gmail.com", new DateTime(1984, 06, 05), "20254", 38, DateTime.UtcNow, 3 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Hank", "Hankerson", "hhank@yahoo.com", new DateTime(1948, 05, 07), "85040", 44, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Mary", "Miller", "mmiller@yahoo.com", new DateTime(1995, 03, 20), "97804", 44, DateTime.UtcNow, 2 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Zeke", "Abelson", "helperman@hotmail.com", new DateTime(1950, 10, 07), "77459", 231, DateTime.UtcNow, 3 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Aaron", "Adams", "aadams@gmail.com", new DateTime(1960, 08, 07), "75849", 231, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Alex", "Zackerman", "azack@yahoo.com", new DateTime(1990, 12, 25), "45455", 1, DateTime.UtcNow, 1 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Paul", "Bunyan", "pbuyan@gmail.com", new DateTime(2018, 05, 10), "75658", 231, DateTime.UtcNow, 2 });

            migrationBuilder.InsertData(
               table: "Customers",
               columns: new[] { "Firstname", "Lastname", "Email", "DateOfBirth", "ZipCode", "Country", "CreatedDate", "SystemRole" },
               values: new object[] { "Gus", "Jacobs", "gus123@hotmail.com", new DateTime(1909, 03, 01), "56660", 44, DateTime.UtcNow, 1 });

            // Add Stored Procedure
            var sqlFile = Path.Combine(Environment.CurrentDirectory, @"Sql/Scripts/CustomerSearch.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

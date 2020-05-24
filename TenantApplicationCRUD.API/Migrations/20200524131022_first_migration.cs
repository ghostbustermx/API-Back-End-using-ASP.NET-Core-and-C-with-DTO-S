using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantApplicationCRUD.API.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantPersonnels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PrefixId = table.Column<int>(nullable: false),
                    GenderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantPersonnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantPersonnels_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Female" });

            migrationBuilder.InsertData(
                table: "TenantPersonnels",
                columns: new[] { "Id", "Active", "DOB", "FirstName", "GenderId", "LastName", "MiddleName", "NickName", "PrefixId" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TEST1", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "TEST1_1_1", "TEST1_1", "TEST1_1_1_1", 0 });

            migrationBuilder.InsertData(
                table: "TenantPersonnels",
                columns: new[] { "Id", "Active", "DOB", "FirstName", "GenderId", "LastName", "MiddleName", "NickName", "PrefixId" },
                values: new object[] { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TEST2", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "TEST2_2_2", "TEST2_2", "TEST2_2_2_2", 0 });

            migrationBuilder.InsertData(
                table: "TenantPersonnels",
                columns: new[] { "Id", "Active", "DOB", "FirstName", "GenderId", "LastName", "MiddleName", "NickName", "PrefixId" },
                values: new object[] { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TEST3", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "TEST3_3_3", "TEST3_3", "TEST3_3_3_3", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TenantPersonnels_GenderId",
                table: "TenantPersonnels",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantPersonnels");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}

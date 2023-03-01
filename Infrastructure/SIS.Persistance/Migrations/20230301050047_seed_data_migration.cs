using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIS.Persistance.Migrations
{
    public partial class seed_data_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a29dc7d9-f490-4d60-a6b8-fd14f8c0e56b", "84987346-c55a-4cda-b758-407dcf518c71", "SuperAdmin", "SUPERADMIN" },
                    { "d7df5c78-a7ab-4a87-8e85-61d557401555", "8fda6b04-935d-45bc-9193-625525613bc2", "trashRole", "TRAHSROLE" },
                    { "e5b1f18e-d3d7-4838-9cd4-c5e66c1eaf7e", "99ad6c18-3483-4caf-9023-f8df8c59ecb2", "Teacher", "TEACHER" },
                    { "e6ffef28-8b4d-483f-806b-d4f5020edf7a", "19e6c9ab-1c8d-4511-b030-6149d42f2356", "Student", "STUDENT" },
                    { "f86174e0-bf79-425e-ba4f-66ff2b78737d", "6acf207c-0f28-4b7f-b452-a3905d203fab", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "ClassNumber", "ConcurrencyStamp", "CreatedDate", "DepartmentId", "Description", "Discriminator", "Email", "EmailConfirmed", "Experience", "FirstName", "Gender", "IdentityRoleName", "ImageSrc", "IsDeleted", "JobDescription", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Qualification", "RemovedDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "000a2387-747a-4b07-9051-120d503e954a", 0, null, null, null, "aec1e4e4-ad9d-4056-845a-16e0aa3b4f16", null, null, null, "AppUser", null, false, null, "Rufat", null, "SuperAdmin", null, false, null, "Talib", false, null, null, "RUFETTALIB", null, null, false, null, null, "7334cbab-8ceb-49af-a99d-4b8aedb9abdd", false, "rufettalib" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 5, 0, 47, 302, DateTimeKind.Utc).AddTicks(8074));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a29dc7d9-f490-4d60-a6b8-fd14f8c0e56b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7df5c78-a7ab-4a87-8e85-61d557401555");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5b1f18e-d3d7-4838-9cd4-c5e66c1eaf7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6ffef28-8b4d-483f-806b-d4f5020edf7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f86174e0-bf79-425e-ba4f-66ff2b78737d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000a2387-747a-4b07-9051-120d503e954a");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9635));
        }
    }
}

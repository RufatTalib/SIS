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
                    { "235cd63c-87e0-4b6f-a994-fab54eca5c65", "24ffea52-7ac6-44cc-ac9b-f8b5222e4188", "Admin", "ADMIN" },
                    { "3d495a91-e90b-4eeb-99e8-6b2b17c72519", "647d9f08-3f76-42dc-b2d1-1637c1600c8a", "SuperAdmin", "SUPERADMIN" },
                    { "881303fe-723e-41e3-81de-d03aa10879ad", "26019bd8-41e3-43b2-bced-50f3b2c792e9", "Student", "STUDENT" },
                    { "c9cd9d50-0e73-4ee8-bb5c-9bd6ec206ef1", "62a43c0b-7238-4f93-9511-3cf2eb86766d", "Teacher", "TEACHER" }
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 6, 51, 7, 251, DateTimeKind.Utc).AddTicks(6190));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235cd63c-87e0-4b6f-a994-fab54eca5c65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d495a91-e90b-4eeb-99e8-6b2b17c72519");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "881303fe-723e-41e3-81de-d03aa10879ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9cd9d50-0e73-4ee8-bb5c-9bd6ec206ef1");

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

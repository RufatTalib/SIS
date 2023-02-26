using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIS.Persistance.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Key", "RemovedDate", "Value" },
                values: new object[,]
                {
                    { 12, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(949), false, "Info", null, "Example information message" },
                    { 13, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(955), false, "Awards", null, "100" },
                    { 14, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(956), false, "FacebookFollowerCount", null, "100" },
                    { 15, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(957), false, "InstagramFollowerCount", null, "100" },
                    { 16, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(958), false, "TwitterFollowerCount", null, "100" },
                    { 17, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(959), false, "LinkedInFollowerCount", null, "100" },
                    { 18, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(960), false, "Adress", null, "Example Adress" },
                    { 19, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1035), false, "Gmail", null, "example@gmail.com" },
                    { 20, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1037), false, "Phone", null, "012 000 00 00" },
                    { 21, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1038), false, "Fax", null, "012 000 00 00" },
                    { 22, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1039), false, "Name", null, "Company Name" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}

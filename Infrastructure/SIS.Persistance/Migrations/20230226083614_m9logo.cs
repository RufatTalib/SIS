using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIS.Persistance.Migrations
{
    public partial class m9logo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9616), "Info", "Example information message" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9622), "Awards" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9623), "FacebookFollowerCount" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9624), "InstagramFollowerCount" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9625), "TwitterFollowerCount" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9626), "LinkedInFollowerCount", "100" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9628), "Adress", "Example Adress" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9629), "Gmail", "example@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9631), "Phone" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9632), "Fax", "012 000 00 00" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Key", "RemovedDate", "Value" },
                values: new object[,]
                {
                    { 23, new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9633), false, "Name", null, "Company Name" },
                    { 24, new DateTime(2023, 2, 26, 8, 36, 14, 132, DateTimeKind.Utc).AddTicks(9635), false, "Logo", null, "~/assets/img/logo.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(955), "Awards", "100" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(956), "FacebookFollowerCount" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(957), "InstagramFollowerCount" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(958), "TwitterFollowerCount" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(959), "LinkedInFollowerCount" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(960), "Adress", "Example Adress" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1035), "Gmail", "example@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1037), "Phone", "012 000 00 00" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "Key" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1038), "Fax" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "Key", "Value" },
                values: new object[] { new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(1039), "Name", "Company Name" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Key", "RemovedDate", "Value" },
                values: new object[] { 12, new DateTime(2023, 2, 26, 8, 13, 16, 479, DateTimeKind.Utc).AddTicks(949), false, "Info", null, "Example information message" });
        }
    }
}

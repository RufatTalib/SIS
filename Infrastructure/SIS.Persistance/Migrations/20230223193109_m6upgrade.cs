using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIS.Persistance.Migrations
{
    public partial class m6upgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_TeacherId",
                table: "Events",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_TeacherId",
                table: "Events",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_TeacherId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_TeacherId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Events");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIS.Persistance.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AspNetUsers_StudentId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_LessonEvent_LessonEventId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonEvent_Groups_GroupId",
                table: "LessonEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonEvent_Subjects_SubjectId",
                table: "LessonEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonEvent",
                table: "LessonEvent");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameTable(
                name: "LessonEvent",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendances",
                newName: "IX_Attendances_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_LessonEventId",
                table: "Attendances",
                newName: "IX_Attendances_LessonEventId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonEvent_SubjectId",
                table: "Events",
                newName: "IX_Events_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonEvent_GroupId",
                table: "Events",
                newName: "IX_Events_GroupId");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassNumber",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Events_LessonEventId",
                table: "Attendances",
                column: "LessonEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Subjects_SubjectId",
                table: "Events",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Events_LessonEventId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Subjects_SubjectId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "LessonEvent");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendance",
                newName: "IX_Attendance_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_LessonEventId",
                table: "Attendance",
                newName: "IX_Attendance_LessonEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_SubjectId",
                table: "LessonEvent",
                newName: "IX_LessonEvent_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_GroupId",
                table: "LessonEvent",
                newName: "IX_LessonEvent_GroupId");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "LessonEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "LessonEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassNumber",
                table: "LessonEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonEvent",
                table: "LessonEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AspNetUsers_StudentId",
                table: "Attendance",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_LessonEvent_LessonEventId",
                table: "Attendance",
                column: "LessonEventId",
                principalTable: "LessonEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonEvent_Groups_GroupId",
                table: "LessonEvent",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonEvent_Subjects_SubjectId",
                table: "LessonEvent",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

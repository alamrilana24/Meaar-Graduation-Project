using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meaar5.Migrations
{
    /// <inheritdoc />
    public partial class RenameFacultyMemberToMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultyCourses_Courses_CourseId",
                table: "FacultyCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultyCourses_FacultyMembers_FacultyId",
                table: "FacultyCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacultyCourses",
                table: "FacultyCourses");

            migrationBuilder.RenameTable(
                name: "FacultyCourses",
                newName: "FacultyCources");

            migrationBuilder.RenameIndex(
                name: "IX_FacultyCourses_FacultyId",
                table: "FacultyCources",
                newName: "IX_FacultyCources_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_FacultyCourses_CourseId",
                table: "FacultyCources",
                newName: "IX_FacultyCources_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacultyCources",
                table: "FacultyCources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyCources_Courses_CourseId",
                table: "FacultyCources",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyCources_FacultyMembers_FacultyId",
                table: "FacultyCources",
                column: "FacultyId",
                principalTable: "FacultyMembers",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultyCources_Courses_CourseId",
                table: "FacultyCources");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultyCources_FacultyMembers_FacultyId",
                table: "FacultyCources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacultyCources",
                table: "FacultyCources");

            migrationBuilder.RenameTable(
                name: "FacultyCources",
                newName: "FacultyCourses");

            migrationBuilder.RenameIndex(
                name: "IX_FacultyCources_FacultyId",
                table: "FacultyCourses",
                newName: "IX_FacultyCourses_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_FacultyCources_CourseId",
                table: "FacultyCourses",
                newName: "IX_FacultyCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacultyCourses",
                table: "FacultyCourses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyCourses_Courses_CourseId",
                table: "FacultyCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyCourses_FacultyMembers_FacultyId",
                table: "FacultyCourses",
                column: "FacultyId",
                principalTable: "FacultyMembers",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meaar5.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTablesAndUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "FacultyCourses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "FacultyMembers",
                columns: table => new
                {
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyMembers", x => x.FacultyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyCourses_CourseId",
                table: "FacultyCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyCourses_FacultyId",
                table: "FacultyCourses",
                column: "FacultyId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultyCourses_Courses_CourseId",
                table: "FacultyCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultyCourses_FacultyMembers_FacultyId",
                table: "FacultyCourses");

            migrationBuilder.DropTable(
                name: "FacultyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FacultyCourses_CourseId",
                table: "FacultyCourses");

            migrationBuilder.DropIndex(
                name: "IX_FacultyCourses_FacultyId",
                table: "FacultyCourses");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "FacultyCourses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

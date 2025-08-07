using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Student_Managmet_MVC.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dapartmant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dapartmant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DapartmantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Dapartmant_DapartmantId",
                        column: x => x.DapartmantId,
                        principalTable: "Dapartmant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DapartmantId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Dapartmant_DapartmantId",
                        column: x => x.DapartmantId,
                        principalTable: "Dapartmant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructors_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DapartmantId = table.Column<int>(type: "int", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Dapartmant_DapartmantId",
                        column: x => x.DapartmantId,
                        principalTable: "Dapartmant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignments",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignments", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_OfficeAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "DapartmantId", "InstructorId", "Name" },
                values: new object[,]
                {
                    { 1, 3, null, null, "C#" },
                    { 2, 4, null, null, "ASP.NET Core" },
                    { 3, 3, null, null, "Databases" },
                    { 4, 3, null, null, "Algorithms" },
                    { 5, 4, null, null, "Operating Systems" }
                });

            migrationBuilder.InsertData(
                table: "Dapartmant",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Information Systems" },
                    { 3, "Business" },
                    { 4, "Engineering" },
                    { 5, "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DapartmantId", "Email", "HireDate", "Name", "StudentId" },
                values: new object[,]
                {
                    { 1, null, "hadeer.mohamed@example.com", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Hadeer Mohamed", null },
                    { 2, null, "mostafa.hassan@example.com", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Mostafa Hassan", null },
                    { 3, null, "rania.ali@example.com", new DateTime(2018, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Rania Ali", null },
                    { 4, null, "tarek.hamed@example.com", new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Tarek Hamed", null },
                    { 5, null, "mona.adel@example.com", new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Mona Adel", null }
                });

            migrationBuilder.InsertData(
                table: "OfficeAssignments",
                columns: new[] { "InstructorId", "Location" },
                values: new object[,]
                {
                    { 1, "Room A101" },
                    { 2, "Room B202" },
                    { 3, "Room C303" },
                    { 4, "Room D404" },
                    { 5, "Room E505" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DapartmantId", "DataOfBirth", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2001, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@example.com", "Ahmed Ali" },
                    { 2, 2, new DateTime(2002, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@example.com", "Sara Mostafa" },
                    { 3, 3, new DateTime(2000, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed@example.com", "Mohamed Tarek" },
                    { 4, 4, new DateTime(2001, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour@example.com", "Nour Ali" },
                    { 5, 5, new DateTime(1999, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef@example.com", "Youssef Hany" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "CourseId", "Date", "IsPresent", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 2, 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 },
                    { 3, 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { 4, 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { 5, 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 1 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", 2 },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C", 3 },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 4 },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B+", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_CourseId",
                table: "Attendances",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DapartmantId",
                table: "Courses",
                column: "DapartmantId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DapartmantId",
                table: "Instructors",
                column: "DapartmantId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StudentId",
                table: "Instructors",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DapartmantId",
                table: "Students",
                column: "DapartmantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "OfficeAssignments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Dapartmant");
        }
    }
}

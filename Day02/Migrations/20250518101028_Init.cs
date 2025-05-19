using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Day02.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_Dept_id",
                        column: x => x.Dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dept_id = table.Column<int>(type: "int", nullable: false),
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_Dept_id",
                        column: x => x.Dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    Crs_Id = table.Column<int>(type: "int", nullable: false),
                    Trainee_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResults_Courses_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseResults_Trainees_Trainee_Id",
                        column: x => x.Trainee_Id,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmed", "CS" },
                    { 2, "Ali", "Math" },
                    { 3, "Omar", "OS" },
                    { 4, "Osama", "Dotnet" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Degree", "Dept_id", "Hours", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, "Bachelor", 1, 0, 50, "Introduction to Programming" },
                    { 2, "Bachelor", 1, 0, 60, "Data Structures and Algorithms" },
                    { 3, "Bachelor", 1, 0, 55, "Database Systems" },
                    { 4, "Bachelor", 2, 0, 50, "Calculus I" },
                    { 5, "Bachelor", 2, 0, 55, "Linear Algebra" },
                    { 6, "Bachelor", 3, 0, 60, "Arch" },
                    { 7, "Master", 3, 0, 65, "ML" },
                    { 8, "Bachelor", 4, 0, 55, "Genetic Algorithms" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Address", "Dept_Id", "Grade", "Imag", "Name" },
                values: new object[,]
                {
                    { 1, "Giza", 1, 70, "m.jpg", "Omar" },
                    { 2, "Giza", 1, 55, "m.jpg", "Ahmed" },
                    { 3, "Cairo", 1, 80, "m.jpg", "Mahmoud" },
                    { 4, "Monoufia", 2, 75, "f.jpg", "Fatma" },
                    { 5, "Alex", 2, 90, "f.jpg", "Omnia" },
                    { 6, "Alex", 3, 66, "f.jpg", "Soha" },
                    { 7, "Cairo", 3, 95, "m.jpg", "Amr" },
                    { 8, "Tanta", 4, 77, "m.jpg", "Eman" },
                    { 9, "Luxur", 4, 100, "m.jpg", "Mohamed" }
                });

            migrationBuilder.InsertData(
                table: "CourseResults",
                columns: new[] { "Id", "Crs_Id", "Degree", "Trainee_Id" },
                values: new object[,]
                {
                    { 1, 1, 85, 1 },
                    { 2, 2, 92, 1 },
                    { 3, 3, 78, 1 },
                    { 4, 1, 88, 2 },
                    { 5, 2, 76, 2 },
                    { 6, 1, 90, 3 },
                    { 7, 4, 95, 4 },
                    { 8, 5, 82, 4 },
                    { 9, 4, 87, 5 },
                    { 10, 6, 91, 6 },
                    { 11, 7, 84, 6 },
                    { 12, 6, 79, 7 },
                    { 13, 8, 93, 8 },
                    { 14, 8, 86, 9 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "Crs_Id", "Dept_id", "Imag", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Giza", 1, 1, "m.jpg", "Ahmed", 65000m },
                    { 2, "Giza", 2, 1, "f.jpg", "Sarah", 72000m },
                    { 3, "Cairo", 3, 1, "f.jpg", "Alaa", 68000m },
                    { 4, "Alex", 4, 2, "f.jpg", "Nour", 70000m },
                    { 5, "Monoufia", 5, 2, "m.jpg", "Mustafa", 75000m },
                    { 6, "Aswan", 6, 3, "m.jpg", "Mohamed", 80000m },
                    { 7, "Luxur", 7, 3, "m.jpg", "Yousef", 85000m },
                    { 8, "Cairo", 8, 4, "m.jpg", "Yassin", 67000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_Crs_Id",
                table: "CourseResults",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_Trainee_Id",
                table: "CourseResults",
                column: "Trainee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Dept_id",
                table: "Courses",
                column: "Dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Crs_Id",
                table: "Instructors",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dept_id",
                table: "Instructors",
                column: "Dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_Dept_Id",
                table: "Trainees",
                column: "Dept_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseResults");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

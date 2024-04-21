using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task8.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Learn the basics of Python programming language, including variables, data types, control structures, functions, and basic algorithms.", "Python Programming Fundamentals" },
                    { 2, "Discover effective digital marketing strategies, including search engine optimization (SEO), social media marketing, email marketing, and content marketing.", "Digital Marketing Strategies" },
                    { 3, "Get started with web development by learning HTML, CSS, and JavaScript fundamentals.", "Web Development Basics" },
                    { 4, "Learn the fundamentals of graphic design, including typography, color theory, layout design, and image manipulation techniques.", "Graphic Design Essentials" },
                    { 5, "Get started with mobile app development by learning about mobile platforms, user interface design, and mobile app development tools.", "Mobile App Development Basics" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ava", "Martin" },
                    { 2, "Adrian", "Herrero" },
                    { 3, "Elena", "Pascual" },
                    { 4, "Diego", "Delgado" },
                    { 5, "Cristina", "Molina" },
                    { 6, "Antonio", "Ortega" },
                    { 7, "Gabriel", "Marquez" },
                    { 8, "Laura", "Santiago" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseId", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, "PPF-01", 1 },
                    { 2, 1, "PPF-02", 1 },
                    { 3, 1, "PPF-03", 2 },
                    { 4, 2, "DMC-01", 3 },
                    { 5, 2, "DMC-02", 4 },
                    { 6, 3, "WDB-01", 5 },
                    { 7, 3, "WDB-02", 6 },
                    { 8, 4, "GDE-01", 7 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 1, "John", 1, "Doe" },
                    { 2, "Alice", 1, "Smith" },
                    { 3, "Michael", 1, "Johnson" },
                    { 4, "Emily", 2, "Brown" },
                    { 5, "Daniel", 3, "Wilson" },
                    { 6, "Jessica", 3, "Martinez" },
                    { 7, "Matthew", 4, "Taylor" },
                    { 8, "Sophia", 5, "Anderson" },
                    { 9, "William", 6, "Thomas" },
                    { 10, "Olivia", 7, "Hernandez" },
                    { 11, "Ethan", 8, "Moore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}

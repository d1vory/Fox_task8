using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Services;

namespace TestTask8;

[TestClass]
public class TestStudentService
{
    public InMemoryAppContext db;

    [TestInitialize]
    public void TestInitialize()
    {
        db = new InMemoryAppContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        
    }

    [TestMethod]
    public void TestDatabaseFilled()
    {
        bool isCourseExist = db.Courses.Any(c => c.Name == "Python Programming Fundamentals");
        Assert.IsTrue(isCourseExist);
    }

    [TestMethod]
    public void TestStudentsExportCsv()
    {
        var group = db.Groups.Find(1);
        Assert.IsNotNull(group);
        var students = db.Students.Where(s => s.Group == group).ToList();
        var filename = Path.Combine("..", "..", "..", "Files", $"{group.Name}.csv");
        StudentService.ExportStudents(filename, students);

        Assert.IsTrue(File.Exists(filename), "File didnt create");
        
        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<ParsedStudent>();
            Assert.AreEqual(students.Count, records.Count());
        }
    }

    [TestMethod]
    public void TestImportStudents()
    {
        var group = db.Groups.Find(2);
        Assert.IsNotNull(group);
        var filename = Path.Combine("..", "..", "..", "Files", "students_for_import.csv");
        StudentService.ImportStudentsToGroup(filename, group, db);
        
        var students = db.Students.Where(s => s.Group == group);
        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<ParsedStudent>();
            var parsedStudents = records as ParsedStudent[] ?? records.ToArray();
            foreach (var rec in parsedStudents)
            {
                Assert.IsTrue(students.Any(s => s.FirstName == rec.FirstName && s.LastName == rec.LastName));
            }
            Assert.AreEqual(students.Count(), parsedStudents.Length);
        }
    }

    [TestMethod]
    public void TestExportStudentsDocX()
    {
        var group = db.Groups.Find(1);
        Assert.IsNotNull(group);
        var students = db.Students.Where(s => s.Group == group).ToList();
        var filename = Path.Combine("..", "..", "..", "Files", $"{group.Name}_2.docx");
        StudentService.ExportStudentsDocX(filename, students, group, db);
        Assert.IsTrue(File.Exists(filename), "File didnt create");
    }

}
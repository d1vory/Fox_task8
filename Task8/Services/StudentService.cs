using System.Globalization;
using System.IO;
using Aspose.Words;
using CsvHelper;
using CsvHelper.Configuration;
using Task8.Data;
using Task8.Models;

namespace Task8.Services;

public class StudentService
{
    public static void ExportStudents(string outputFilename, ICollection<Student> students)
    {
        using (StreamWriter writer = new StreamWriter(outputFilename))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<ParsedStudent>();
            csv.NextRecord();
            foreach (var s in students)
            {
                var parsedStudent = new ParsedStudent()
                {
                    FirstName = s.FirstName, LastName = s.LastName
                };
                csv.WriteRecord(parsedStudent);
                csv.NextRecord();
            }
        }
    }

    public static void ImportStudentsToGroup(string inputFileName, Group group, BaseApplicationContext db)
    {
        var studentsToRemove = db.Students.Where(s => s.Group == group);
        db.Students.RemoveRange(studentsToRemove);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        config.TrimOptions = TrimOptions.Trim;
        using (var reader = new StreamReader(inputFileName))
        using (var csv = new CsvReader(reader, config))
        {
            while (csv.Read())
            {
                ParsedStudent record;
                try
                {
                    record = csv.GetRecord<ParsedStudent>();
                }
                catch (CsvHelperException ex)
                {
                    continue;
                }

                var student = new Student()
                {
                    FirstName = record.FirstName, LastName = record.LastName, GroupId = group.Id
                };
                db.Add(student);
            }
        }

        db.SaveChanges();
    }

    public static void ExportStudentsDocX(string outputFilename, ICollection<Student> students, Group group, BaseApplicationContext db)
    {
        var doc = new Document();
        var builder = new DocumentBuilder(doc);

        builder.Font.Size = 16;
        builder.Bold = true;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        var course = db.Courses.FirstOrDefault(c => c.Id == group.CourseId);
        builder.Writeln($"Students of {group.Name} in course '{course?.Name}'");

        builder.Font.Size = 14;
        builder.Bold = false;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;

        builder.ListFormat.ApplyNumberDefault();

        foreach (var st in students)
        {
            builder.Writeln($"{st.LastName} {st.FirstName}");
        }

        builder.ListFormat.RemoveNumbers();
        doc.Save(outputFilename);
    }
}
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using Aspose.Words;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Views.Pages;

namespace Task8.ViewModels;

public partial class StudentListViewModel: ObservableObject
{
    private Frame _mainFrame;
    private SqlServerAppContext _db = new SqlServerAppContext();
    public ObservableCollection<Student> Students { get; set; }
    public Group MyGroup { get; set; }
    
    
    public StudentListViewModel(Group group, Frame mainFrame)
    {
        _db.Students.Where(s => s.Group == group).Load();
        Students = _db.Students.Local.ToObservableCollection();
        MyGroup = group;
        _mainFrame = mainFrame;
    }
    
    [RelayCommand]
    private void AddStudent()
    {
        var studentWindow = new StudentWindow(new Student());
        if (studentWindow.ShowDialog() == true)
        {
            var student = studentWindow.Student;
            student.GroupId = MyGroup.Id;
            _db.Students.Add(student);
            _db.SaveChanges();
        }
    }
    
    [RelayCommand]
    private void EditStudent(Student? selectedStudent)
    {
        if(selectedStudent == null) return;

        var tempStudent = new Student()
        {
            Id = selectedStudent.Id,
            FirstName = selectedStudent.FirstName,
            LastName = selectedStudent.LastName,
            Group = selectedStudent.Group
        };
        
        var studentWindow = new StudentWindow(tempStudent);
        if (studentWindow.ShowDialog() == true)
        {
            selectedStudent.FirstName = studentWindow.Student.FirstName;
            selectedStudent.LastName = studentWindow.Student.LastName;
            _db.Entry(selectedStudent).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
    
    [RelayCommand]
    private void DeleteStudent(Student? selectedStudent)
    {
        if( selectedStudent == null) return;
        _db.Students.Remove(selectedStudent);
        _db.SaveChanges();
    }

    [RelayCommand]
    private void ExportStudents()
    {
        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
        dlg.FileName = $"Students_{MyGroup.Name}"; // Default file name
        dlg.DefaultExt = ".csv"; // Default file extension
        dlg.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension
        
        var result = dlg.ShowDialog();
        if (!result.HasValue || !result.Value) return;
        var fileName = dlg.FileName;
        using (StreamWriter outputFile = new StreamWriter(fileName))
        using (var csv = new CsvWriter(outputFile, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<ParsedStudent>();
            csv.NextRecord();
            foreach (var s in Students)
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

    [RelayCommand]
    private void ImportStudents()
    {
        var dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension
        var result = dlg.ShowDialog();
        if (!result.HasValue || !result.Value) return;
        var fileName = dlg.FileName;

        var studentsToRemove = _db.Students.Where(s => s.Group == MyGroup);
        _db.Students.RemoveRange(studentsToRemove);
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        config.TrimOptions = TrimOptions.Trim;
        using (var reader = new StreamReader(fileName))
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
                    FirstName = record.FirstName, LastName = record.LastName, GroupId = MyGroup.Id
                };
                _db.Add(student);
            }
        }
        _db.SaveChanges();
    }
    
    [RelayCommand]
    private void ExportStudentsDocX()
    {
        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
        dlg.FileName = $"Students_{MyGroup.Name}"; // Default file name
        dlg.DefaultExt = ".docx"; // Default file extension
        dlg.Filter = "Text documents (.docx)|*.docx"; // Filter files by extension
        
        var result = dlg.ShowDialog();
        if (!result.HasValue || !result.Value) return;
        
        var doc = new Document();
        var builder = new DocumentBuilder(doc);
        
        builder.ListFormat.ApplyNumberDefault();

        foreach (var st in Students)
        {
            builder.Writeln($"{st.LastName} {st.FirstName}");
        }
        builder.ListFormat.RemoveNumbers();
        doc.Save(dlg.FileName);
    }

        
}
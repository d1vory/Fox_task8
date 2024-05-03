using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using Aspose.Words;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Services;
using Task8.Views.Pages;

namespace Task8.ViewModels;

public partial class StudentListViewModel : ObservableObject
{
    public ObservableCollection<Student> Students { get; set; }
    public Group MyGroup { get; set; }
    private Frame _mainFrame;
    private SqlServerAppContext _db = new SqlServerAppContext();


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
        if (studentWindow.ShowDialog() != true) return;
        var studentWindowViewModel = studentWindow.ViewModel;
        var student = studentWindowViewModel.MyStudent;
        student.GroupId = MyGroup.Id;
        _db.Students.Add(student);
        _db.SaveChanges();
    }

    [RelayCommand]
    private void EditStudent(Student? selectedStudent)
    {
        if (selectedStudent == null) return;

        var tempStudent = new Student()
        {
            Id = selectedStudent.Id,
            FirstName = selectedStudent.FirstName,
            LastName = selectedStudent.LastName,
            Group = selectedStudent.Group
        };
        var studentWindow = new StudentWindow(tempStudent);
        if (studentWindow.ShowDialog() != true) return;
        var studentWindowViewModel = studentWindow.ViewModel;
        var editedStudent = studentWindowViewModel.MyStudent;
        selectedStudent.FirstName = editedStudent.FirstName;
        selectedStudent.LastName = editedStudent.LastName;
        _db.Entry(selectedStudent).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [RelayCommand]
    private void DeleteStudent(Student? selectedStudent)
    {
        if (selectedStudent == null) return;
        _db.Students.Remove(selectedStudent);
        _db.SaveChanges();
    }

    [RelayCommand]
    private void ExportStudents()
    {
        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
        dlg.FileName = $"Students_{MyGroup.Name}";
        dlg.DefaultExt = ".csv";
        dlg.Filter = "Text documents (.csv)|*.csv";

        var result = dlg.ShowDialog();
        if (!result.HasValue || !result.Value) return;
        var fileName = dlg.FileName;
        StudentService.ExportStudents(fileName, Students);
        MessageBox.Show($"Saved at {fileName}");
    }

    [RelayCommand]
    private void ImportStudents()
    {
        var dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.Filter = "Text documents (.csv)|*.csv";
        var result = dlg.ShowDialog();
        if (!result.HasValue || !result.Value) return;
        var fileName = dlg.FileName;
        StudentService.ImportStudentsToGroup(fileName, MyGroup, _db);
    }

    [RelayCommand]
    private void ExportStudentsDocX()
    {
        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
        dlg.FileName = $"Students_{MyGroup.Name}";
        dlg.DefaultExt = ".docx";
        dlg.Filter = "Text documents (.docx)|*.docx";

        var result = dlg.ShowDialog();
        if (!result.HasValue || !result.Value) return;
        var fileName = dlg.FileName;
        StudentService.ExportStudentsDocX(fileName, Students, MyGroup, _db);
        
        MessageBox.Show($"Saved at {dlg.FileName}");
    }
}
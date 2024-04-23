using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        
}
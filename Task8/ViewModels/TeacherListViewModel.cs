using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Views.Windows;

namespace Task8.ViewModels;

public partial class TeacherListViewModel: ObservableObject
{
    public ObservableCollection<Teacher> Teachers { get; set; }
    private Frame _mainFrame;
    private SqlServerAppContext _db = new SqlServerAppContext();


    public TeacherListViewModel(Frame mainFrame)
    {
        _db.Teachers.Load();
        Teachers = _db.Teachers.Local.ToObservableCollection();
        _mainFrame = mainFrame;
    }

    [RelayCommand]
    private void AddTeacher()
    {
        var teacherWindow = new TeacherWindow(new Teacher());
        if (teacherWindow.ShowDialog() == true)
        {
            var teacher = teacherWindow.Teacher;
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
        }
    }
    
    [RelayCommand]
    private void EditTeacher(Teacher? selectedTeacher)
    {
        if (selectedTeacher == null) return;
    
        var tempTeacher = new Teacher()
        {
            Id = selectedTeacher.Id,
            FirstName = selectedTeacher.FirstName,
            LastName = selectedTeacher.LastName,
        };
    
        var teacherWindow = new TeacherWindow(tempTeacher);
        if (teacherWindow.ShowDialog() == true)
        {
            selectedTeacher.FirstName = teacherWindow.Teacher.FirstName;
            selectedTeacher.LastName = teacherWindow.Teacher.LastName;
            _db.Entry(selectedTeacher).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }

    [RelayCommand]
    private void DeleteTeacher(Teacher? selectedTeacher)
    {
        if (selectedTeacher == null) return;
        _db.Teachers.Remove(selectedTeacher);
        _db.SaveChanges();
    }
}
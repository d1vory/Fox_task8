using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Forms;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Views.Pages;

namespace Task8.ViewModels;

public partial class CourseListViewModel: ObservableObject
{
    private Frame _mainFrame;
    private SqlServerAppContext _db = new SqlServerAppContext();
    public ObservableCollection<Course> Courses { get; }

    public CourseListViewModel(Frame mainFrame)
    {
        _db.Courses.Load();
        Courses = _db.Courses.Local.ToObservableCollection();
        _mainFrame = mainFrame;
    }
    
    [RelayCommand]
    private void AddCourse()
    {
        CourseWindow courseWindow = new CourseWindow(new Course());
        if (courseWindow.ShowDialog() == true)
        {
            var course = courseWindow.Course;
            _db.Courses.Add(course);
            _db.SaveChanges();
        }
    }

    [RelayCommand]
    private void EditCourse(Course? selectedCourse)
    {
        if( selectedCourse == null) return;

        var tempCourse = new Course()
        {
            Id = selectedCourse.Id,
            Name = selectedCourse.Name,
            Description = selectedCourse.Description
        };
        
        CourseWindow courseWindow = new CourseWindow(tempCourse);
        if (courseWindow.ShowDialog() == true)
        {
            selectedCourse.Name = courseWindow.Course.Name;
            selectedCourse.Description = courseWindow.Course.Description;
            _db.Entry(selectedCourse).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }

    [RelayCommand]
    private void DeleteCourse(Course? selectedCourse)
    {
        if( selectedCourse == null) return;
        if (_db.Groups.Any(g => g.Course == selectedCourse))
        {
            MessageBox.Show("Unable to delete a course with groups.");
            return;
        }
        _db.Courses.Remove(selectedCourse);
        _db.SaveChanges();
    }
    
    [RelayCommand]
    private void ListOfGroups(Course? selectedCourse)
    {
        if( selectedCourse == null) return;
        _mainFrame.Content = new GroupsList(selectedCourse, _mainFrame);
        
    }
}
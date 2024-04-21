using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Views.Pages;

namespace Task8.ViewModels;

public partial class CourseListViewModel: ObservableObject
{
    private SqlServerAppContext _db = new SqlServerAppContext();
    public ObservableCollection<Course> Courses { get; } = new ObservableCollection<Course>();

    public CourseListViewModel()
    {
        _db.Courses.Load();
        Courses = _db.Courses.Local.ToObservableCollection();
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
        _db.Courses.Remove(selectedCourse);
        _db.SaveChanges();
    }
}
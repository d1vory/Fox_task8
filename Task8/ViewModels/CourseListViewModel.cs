using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Models.Wrappers;
using Task8.Views.Pages;

namespace Task8.ViewModels;

public partial class CourseListViewModel: ObservableObject
{
    private SqlServerAppContext _db = new SqlServerAppContext();
    public ObservableCollection<ObservableCourse> Courses { get; } = new ObservableCollection<ObservableCourse>();

    public CourseListViewModel()
    {
        _db.Courses.Load();
        foreach (var c in _db.Courses.Local.ToObservableCollection())
        {
            Courses.Add(new ObservableCourse(c));
        }

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
            Courses.Add(new ObservableCourse(course));
        }
    }

    [RelayCommand]
    private void EditCourse(ObservableCourse? selectedCourse)
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
            selectedCourse.SaveChanges(_db);
        }
    }

}
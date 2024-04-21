using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Task8.Data;

namespace Task8.Models.Wrappers;

public class ObservableCourse: ObservableObject
{
    private readonly Course _course;

    public ObservableCourse(Course course)
    {
        _course = course;
    }

    public int Id
    {
        get => _course.Id;
    }

    public string Name
    {
        get => _course.Name;
        set => SetProperty(_course.Name, value, _course, (u, n) => u.Name = n);
    }
    
    public string Description
    {
        get => _course.Description;
        set => SetProperty(_course.Description, value, _course, (u, n) => u.Description = n);
    }

    public void SaveChanges(SqlServerAppContext db, EntityState state = EntityState.Modified)
    {
        db.Entry(_course).State = state;
        db.SaveChanges();
    }

    public void Delete(SqlServerAppContext db)
    {
        
    }
}
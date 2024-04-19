using CommunityToolkit.Mvvm.ComponentModel;

namespace Task8.Models.Wrappers;

public class ObservableCourse: ObservableObject
{
    private readonly Course _course;

    public ObservableCourse(Course course)
    {
        _course = course;
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
}
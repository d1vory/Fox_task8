using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Task8.Models;

public class Group: ObservableObject
{
    public int Id { get; set; }
    private string _name = null!;
    private int _courseId;
    private Course _course = null!;
    private int _teacherId;
    private Teacher _teacher = null!;
    private int _studentId;
    private Student _student = null!;
    
    [StringLength(50)] 
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    
    public  int CourseId 
    {
        get => _courseId;
        set => SetProperty(ref _courseId, value);
    }
    public Course Course
    {
        get => _course;
        set => SetProperty(ref _course, value);
    }
    
    public  int TeacherId 
    {
        get => _teacherId;
        set => SetProperty(ref _teacherId, value);
    }
    public Teacher Teacher
    {
        get => _teacher;
        set => SetProperty(ref _teacher, value);
    }

    public  int StudentId 
    {
        get => _studentId;
        set => SetProperty(ref _studentId, value);
    }
    public Student Student
    {
        get => _student;
        set => SetProperty(ref _student, value);
    }
}
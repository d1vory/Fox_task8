using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using Task8.Data;
using Task8.Models;

namespace Task8.ViewModels;

public class CourseWindowViewModel: ObservableValidator
{
    public Course MyCourse { get; set; }
    private string _name = null!;
    private string _description = null!;
    
    [Required(ErrorMessage = "Field is Required")]
    [StringLength(250)]
    [CustomValidation(typeof(CourseWindowViewModel), nameof(ValidateName))]
    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value, false);
            MyCourse.Name = value;
        }
    }
    
    [Required(ErrorMessage = "Field is Required")]
    [StringLength(1000)]
    public string Description
    {
        get => _description;
        set
        {
            SetProperty(ref _description, value, false);
            MyCourse.Description = value;
        }
    }

    public CourseWindowViewModel(Course course)
    {
        MyCourse = course;
        _name = course.Name;
        _description = course.Description;
    }
    
    public bool CanSubmit()
    {
        ValidateAllProperties();
        return !HasErrors;
    }

    public static ValidationResult ValidateName(string name, ValidationContext context)
    {
        var db = new SqlServerAppContext();
        bool isExist = db.Courses.Any(c => c.Name == name);
        if (!isExist)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Provided name already exists");
    }
    
    
}
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using Task8.Models;

namespace Task8.ViewModels;

public class TeacherWindowViewModel: ObservableValidator
{
    public Teacher MyTeacher { get; set; }
    private string _firstName = null!;
    private string _lastName = null!;

    [Required(ErrorMessage = "Field is Required")]
    [StringLength(50)]
    public string FirstName
    {
        get => _firstName;
        set
        {
            SetProperty(ref _firstName, value, false);
            MyTeacher.FirstName = value;
        }
    }
    
    
    [Required(ErrorMessage = "Field is Required")]
    [StringLength(50)]
    public string LastName
    {
        get => _lastName;
        set
        {
            SetProperty(ref _lastName, value, false);
            MyTeacher.LastName = value;
        }
    }

    public TeacherWindowViewModel(Teacher teacher)
    {
        MyTeacher = teacher;
        _firstName = teacher.FirstName;
        _lastName = teacher.LastName;
    }
    
    public bool CanSubmit()
    {
        ValidateAllProperties();
        return !HasErrors;
    }
}
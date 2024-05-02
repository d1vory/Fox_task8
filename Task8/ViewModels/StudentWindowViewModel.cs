using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using Task8.Models;

namespace Task8.ViewModels;

public class StudentWindowViewModel: ObservableValidator
{
    public Student MyStudent { get; set; }
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
            MyStudent.FirstName = value;
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
            MyStudent.LastName = value;
        }
    }

    public StudentWindowViewModel(Student student)
    {
        MyStudent = student;
        _firstName = student.FirstName;
        _lastName = student.LastName;
    }
    
    public bool CanSubmit()
    {
        ValidateAllProperties();
        return !HasErrors;
    }
}
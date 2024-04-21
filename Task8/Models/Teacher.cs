using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Task8.Models;

public class Teacher: ObservableObject
{
    public int Id { get; set; }
    private string _firstName = null!;
    private string _lastName = null!;
    
    [StringLength(50)]
    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }
    
    [StringLength(50)]
    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }
}
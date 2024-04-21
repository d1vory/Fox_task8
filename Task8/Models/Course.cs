using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Task8.Models;

public class Course : ObservableObject
{
    public int Id { get; set; }
    private string _name = null!;
    private string _description = null!;
    
    [StringLength(250)]
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    
    [StringLength(1000)]
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }
}
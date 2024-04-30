using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;

namespace Task8.ViewModels;

public partial class GroupWindowViewModel : ObservableValidator
{
    public Group MyGroup { get; set; }
    public ObservableCollection<Teacher> Teachers { get; }
    private SqlServerAppContext _db;
    private string _groupName;
    private Teacher _selectedTeacher;
    

    [Required(ErrorMessage = "Name is Required")]
    [MaxLength(50, ErrorMessage = "Max length reached")]
    public string GroupName
    {
        get => _groupName;
        set
        {
            SetProperty(ref _groupName, value, true);
            MyGroup.Name = value;
        }
    }

    [Required(ErrorMessage = "Field is Required")]
    public Teacher SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            SetProperty(ref _selectedTeacher, value, true);
            MyGroup.Teacher = value;
        }
    }
    
    
    public GroupWindowViewModel(Group group, SqlServerAppContext db)
    {
        _db = db;
        _db.Teachers.Load();
        Teachers = _db.Teachers.Local.ToObservableCollection();
        MyGroup = group;
        _groupName = group.Name;
        _selectedTeacher = group.Teacher;
    }
    
    
    public bool CanSubmit()
    {
        ValidateAllProperties();
        return !HasErrors;
    }
}
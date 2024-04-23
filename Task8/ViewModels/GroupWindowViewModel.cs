using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;

namespace Task8.ViewModels;

public partial class GroupWindowViewModel : ObservableObject
{
    public Group MyGroup { get; set; }
    public ObservableCollection<Teacher> Teachers { get; }
    //public Teacher SelectedTeacher { get; set; }
    private SqlServerAppContext _db;
    
    public GroupWindowViewModel(Group group, SqlServerAppContext db)
    {
        _db = db;
        _db.Teachers.Load();
        Teachers = _db.Teachers.Local.ToObservableCollection();
        MyGroup = group;
    }
   
}
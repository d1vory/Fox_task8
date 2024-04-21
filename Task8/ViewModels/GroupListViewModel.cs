using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;

namespace Task8.ViewModels;

public class GroupListViewModel: ObservableObject
{
    private SqlServerAppContext _db = new SqlServerAppContext();
    public ObservableCollection<Group> Groups { get; }
    
    
    public GroupListViewModel(Course course)
    {
        _db.Groups.Where(g => g.Course == course).Load();
        Groups = _db.Groups.Local.ToObservableCollection();
    }

    
}
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Views.Pages;

namespace Task8.ViewModels;

public partial class GroupListViewModel: ObservableObject
{
    private SqlServerAppContext _db = new SqlServerAppContext();
    public ObservableCollection<Group> Groups { get; }
    public Course MyCourse { get; set; }
    
    
    public GroupListViewModel(Course course)
    {
        _db.Groups.Include(g => g.Teacher).Where(g => g.Course == course).Load();
        Groups = _db.Groups.Local.ToObservableCollection();
        MyCourse = course;
    }
    
        
    [RelayCommand]
    private void AddGroup()
    {
        var groupWindow = new GroupWindow(new Group(), _db);
        if (groupWindow.ShowDialog() != true) return;
        var groupWindowViewModel = (GroupWindowViewModel)groupWindow.DataContext;
        var group = groupWindowViewModel.MyGroup;
        group.TeacherId = groupWindowViewModel.SelectedTeacher.Id;
        group.CourseId = MyCourse.Id;
        
        _db.Groups.Add(group);
        _db.SaveChanges();
    }
    
    
    [RelayCommand]
    private void EditGroup(Group? selectedGroup)
    {
        if( selectedGroup == null) return;


    }

    
}
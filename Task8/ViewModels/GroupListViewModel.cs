using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Forms;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;
using Task8.Views.Pages;

namespace Task8.ViewModels;

public partial class GroupListViewModel : ObservableObject
{
    public ObservableCollection<Group> Groups { get; }
    public Course MyCourse { get; set; }
    private Frame _mainFrame;
    private SqlServerAppContext _db = new SqlServerAppContext();


    public GroupListViewModel(Course course, Frame mainFrame)
    {
        _db.Groups.Include(g => g.Teacher).Where(g => g.Course == course).Load();
        Groups = _db.Groups.Local.ToObservableCollection();
        MyCourse = course;
        _mainFrame = mainFrame;
    }


    [RelayCommand]
    private void AddGroup()
    {
        var groupWindow = new GroupWindow(new Group(), _db);
        if (groupWindow.ShowDialog() != true) return;
        var groupWindowViewModel = groupWindow.ViewModel;
        var group = groupWindowViewModel.MyGroup;
        group.CourseId = MyCourse.Id;

        _db.Groups.Add(group);
        _db.SaveChanges();
    }


    [RelayCommand]
    private void EditGroup(Group? selectedGroup)
    {
        if (selectedGroup == null) return;
        var tempGroup = new Group()
        {
            Id = selectedGroup.Id,
            Course = selectedGroup.Course,
            Name = selectedGroup.Name,
            Teacher = selectedGroup.Teacher
        };
        var groupWindow = new GroupWindow(tempGroup, _db);
        if (groupWindow.ShowDialog() != true) return;
        var groupWindowViewModel = groupWindow.ViewModel;
        var editedGroup = groupWindowViewModel.MyGroup;

        selectedGroup.Name = editedGroup.Name;
        selectedGroup.Teacher = editedGroup.Teacher;

        _db.Entry(selectedGroup).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [RelayCommand]
    private void DeleteGroup(Group? selectedGroup)
    {
        if (selectedGroup == null) return;
        if (_db.Students.Any(s => s.Group == selectedGroup))
        {
            MessageBox.Show("Unable to delete a group with students.");
            return;
        }

        _db.Groups.Remove(selectedGroup);
        _db.SaveChanges();
    }


    [RelayCommand]
    private void ListOfStudents(Group? selectedGroup)
    {
        if (selectedGroup == null) return;
        _mainFrame.Content = new StudentsList(selectedGroup, _mainFrame);
    }
}
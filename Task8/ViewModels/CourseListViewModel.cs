using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Task8.Models;

namespace Task8.ViewModels;

public partial class CourseListViewModel: ObservableObject
{
    public ObservableCollection<Course> Courses { get; } = new ObservableCollection<Course>();

    // [ObservableProperty]
    // private string _name;
    // [ObservableProperty]
    // private string _description;

}
using System.Windows.Controls;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class GroupsList : Page
{
    public GroupsList(Course course)
    {
        InitializeComponent();
        DataContext = new GroupListViewModel(course);
    }
}
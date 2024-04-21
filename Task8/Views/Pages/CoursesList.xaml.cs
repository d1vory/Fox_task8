using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class CoursesList : Page
{
    public CoursesList(Frame mainFrame)
    {
        InitializeComponent();
        DataContext = new CourseListViewModel(mainFrame);
    }
}
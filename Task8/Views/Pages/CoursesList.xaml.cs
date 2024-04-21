using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class CoursesList : Page
{
    public CoursesList()
    {
        InitializeComponent();
        DataContext = new CourseListViewModel();
    }
    
    //internal CourseListViewModel ViewModel => Ioc.Default.GetService<CourseListViewModel>();
}
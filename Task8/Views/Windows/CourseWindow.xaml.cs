using System.Windows;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class CourseWindow : Window
{
    public CourseWindowViewModel ViewModel { get; private set; }
    
    public CourseWindow(Course course)
    {
        InitializeComponent();
        ViewModel = new CourseWindowViewModel(course);
        DataContext = ViewModel;
    }
    
    void Accept_Click(object sender, RoutedEventArgs e)
    {
        if (ViewModel.CanSubmit())
        {
            DialogResult = true;
        }
    }
}
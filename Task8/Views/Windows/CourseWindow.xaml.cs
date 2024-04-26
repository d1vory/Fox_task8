using System.Windows;
using Task8.Models;

namespace Task8.Views.Pages;

public partial class CourseWindow : Window
{
    public Course Course { get; private set; }
    public CourseWindow(Course course)
    {
        InitializeComponent();
        Course = course;
        DataContext = Course;
    }
    
    void Accept_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
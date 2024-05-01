using System.Windows;
using Task8.Models;

namespace Task8.Views.Windows;

public partial class TeacherWindow : Window
{
    public Teacher Teacher { get; private set; }
    
    public TeacherWindow(Teacher teacher)
    {
        InitializeComponent();
        Teacher = teacher;
        DataContext = Teacher;
    }
    
    void Accept_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
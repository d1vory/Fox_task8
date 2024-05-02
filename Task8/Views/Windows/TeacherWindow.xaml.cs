using System.Windows;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Windows;

public partial class TeacherWindow : Window
{
    public TeacherWindowViewModel ViewModel { get; private set; }
    
    public TeacherWindow(Teacher teacher)
    {
        InitializeComponent();
        ViewModel = new TeacherWindowViewModel(teacher);
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
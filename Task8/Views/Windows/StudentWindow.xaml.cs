using System.Windows;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class StudentWindow : Window
{
    public StudentWindowViewModel ViewModel { get; private set; }
    
    public StudentWindow(Student student)
    {
        InitializeComponent();
        ViewModel = new StudentWindowViewModel(student);
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

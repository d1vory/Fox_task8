using System.Windows;
using Task8.Data;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class GroupWindow : Window
{
    public GroupWindowViewModel ViewModel { get; private set; }
    
    public GroupWindow(Group group, SqlServerAppContext db)
    {
        InitializeComponent();
        ViewModel = new GroupWindowViewModel(group, db);
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
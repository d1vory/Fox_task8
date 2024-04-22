using System.Windows;
using Task8.Data;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class GroupWindow : Window
{
    public GroupWindow(Group group, SqlServerAppContext db)
    {
        InitializeComponent();
        DataContext = new GroupWindowViewModel(group, db);
    }
    
    void Accept_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
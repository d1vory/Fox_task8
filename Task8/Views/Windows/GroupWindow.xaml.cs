using System.Windows;
using Task8.Data;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class GroupWindow : Window
{
    private GroupWindowViewModel _viewModel;
    
    public GroupWindow(Group group, SqlServerAppContext db)
    {
        InitializeComponent();
        _viewModel = new GroupWindowViewModel(group, db);
        DataContext = _viewModel;
    }
    
    void Accept_Click(object sender, RoutedEventArgs e)
    {
        if (_viewModel.CanSubmit())
        {
            DialogResult = true;
        }
    }
}
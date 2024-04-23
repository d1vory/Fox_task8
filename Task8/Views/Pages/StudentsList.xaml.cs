using System.Windows.Controls;
using Task8.Models;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class StudentsList : Page
{
    public StudentsList(Group group, Frame mainFrame)
    {
        InitializeComponent();
        DataContext = new StudentListViewModel(group, mainFrame);
    }
}
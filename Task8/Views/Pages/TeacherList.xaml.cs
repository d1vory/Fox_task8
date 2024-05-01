using System.Windows.Controls;
using Task8.ViewModels;

namespace Task8.Views.Pages;

public partial class TeacherList : Page
{
    public TeacherList(Frame mainFrame)
    {
        InitializeComponent();
        DataContext = new TeacherListViewModel(mainFrame);
    }
}
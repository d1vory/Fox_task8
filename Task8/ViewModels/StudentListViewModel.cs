using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Task8.Data;
using Task8.Models;

namespace Task8.ViewModels;

public class StudentListViewModel: ObservableObject
{
    private Frame _mainFrame;
    private SqlServerAppContext _db = new SqlServerAppContext();
    public ObservableCollection<Student> Students { get; set; }
    public Group MyGroup { get; set; }
    
    
    public StudentListViewModel(Group group, Frame mainFrame)
    {
        _db.Students.Where(s => s.Group == group).Load();
        Students = _db.Students.Local.ToObservableCollection();
        MyGroup = group;
        _mainFrame = mainFrame;
    }
        
}
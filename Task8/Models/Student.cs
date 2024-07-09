using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Task8.Models;

public class Student: ObservableObject
{
        public int Id { get; set; }
        private string _firstName = null!;
        private string _lastName = null!;
        private int _groupId;
        private Group _group;
        
        [StringLength(50)]
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        
        [StringLength(50)]
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        
        public int GroupId 
        {
            get => _groupId;
            set => SetProperty(ref _groupId, value);
        }
        public Group Group
        {
            get => _group;
            set => SetProperty(ref _group, value);
        }
}

public class ParsedStudent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}
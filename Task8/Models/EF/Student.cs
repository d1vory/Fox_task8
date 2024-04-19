using System.ComponentModel.DataAnnotations;

namespace Task8.Models;

public class Student
{
    public int Id { get; set; }
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    [StringLength(50)]
    public string LastName { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;

namespace Task8.Models;

public class Course
{
    public int Id { get; set; }
    [StringLength(250)]
    public string Name { get; set; } = null!;
    [StringLength(1000)]
    public string Description { get; set; } = null!;
}
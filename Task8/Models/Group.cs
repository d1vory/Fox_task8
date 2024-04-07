using System.ComponentModel.DataAnnotations;

namespace Task8.Models;

public class Group
{
    public int Id { get; set; }
    [StringLength(50)] public string Name { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}
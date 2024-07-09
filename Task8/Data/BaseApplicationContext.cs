using Microsoft.EntityFrameworkCore;
using Task8.Models;

namespace Task8.Data;

public class BaseApplicationContext: DbContext
{
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}
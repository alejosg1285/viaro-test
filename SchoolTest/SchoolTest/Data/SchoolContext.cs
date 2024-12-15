using Microsoft.EntityFrameworkCore;
using SchoolTest.Models;

namespace SchoolTest.Data;

public class SchoolContext(DbContextOptions<SchoolContext> options) : DbContext(options)
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<StudentGrade> StudentGrades { get; set; }
}

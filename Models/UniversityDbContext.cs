using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace University.Models
{
  public class UniversityContext: DbContext
  {
    public virtual DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
     public DbSet<Department> Departments { get; set; }

    public DbSet<CourseStudent> CourseStudent { get; set; }


    public UniversityContext(DbContextOptions options) : base(options) { }
  
  
  }
}
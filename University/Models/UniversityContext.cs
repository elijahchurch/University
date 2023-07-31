using Microsoft.EntityFrameworkCore;

namespace University.Models
{
    public class UniversityContext: DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Course> Courses {get;set;}
        public DbSet<StudentCourse> StudentCourses {get;set;}

        public UniversityContext(DbContextOptions options) : base(options){}
    }
}
namespace University.Models
{
    public class StudentCourse
    {
        public int StudentCourseID {get; set;}
        public int StudentId {get; set;}
        public Student Student {get; set;}
        public int CourseId {get; set;}
        public Course Course {get; set;}
    }
}
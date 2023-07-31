using System.Collections.Generic;

namespace University.Models
{
    public class Course
    {
        public int CourseId {get; set;}
        public string Name {get; set;}
        public string CourseNumber {get; set;}
        public List<StudentCourse> JoinEntities {get;}
    }
}
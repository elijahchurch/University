using System.Collections.Generic;


namespace University.Models
{
    public class Student
    {
        public int StudentId {get; set;}
        public string Name {get; set;}
        public string EnrollmentDate {get; set;}
        public List<StudentCourse> JoinEntities {get;}

    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace University.Controllers
{
    public class StudentsController: Controller
    {
        private readonly UniversityContext _db;
        public StudentsController(UniversityContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Student> model = _db.Students.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Student thisStudent = _db.Students
                    .Include(student => student.JoinEntities)
                    .ThenInclude(join => join.Course)
                    .FirstOrDefault(student => student.StudentId == id);
            return View(thisStudent);
        }

        public ActionResult AddCourse(int id)
        {
        Student thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
        return View(thisStudent);
        }

        [HttpPost]
        public ActionResult AddCourse(Student student, int courseId)
        {
            #nullable enable 
            StudentCourse? joinEntity = _db.StudentCourses.FirstOrDefault(join => (join.StudentId == student.StudentId && join.CourseId == courseId));
            #nullable disable
            if (joinEntity == null && courseId != 0)
            {
                _db.StudentCourses.Add( new StudentCourse() {StudentId = student.StudentId, CourseId = courseId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new {id = student.StudentId});
        }
    }
}
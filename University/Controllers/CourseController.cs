using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace University.Controllers
{
    public class CoursesController: Controller
    {
        private readonly UniversityContext _db;
        public CoursesController(UniversityContext db)
        {
            _db = db;
        }
         public ActionResult Index()
        {
            List<Course> model = _db.Courses.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
          public ActionResult Details(int id)
        {
            Course thisCourse = _db.Courses
                    .Include(course => course.JoinEntities)
                    .ThenInclude(join => join.Student)
                    .FirstOrDefault(course => course.CourseId == id);
            return View(thisCourse);
        }
        
    public ActionResult AddStudent(int id)
    {
      Course thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "Name");
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult AddStudent(Course course, int studentId)
    {
      #nullable enable
      StudentCourse? joinEntity = _db.StudentCourses.FirstOrDefault(join => (join.CourseId == course.CourseId && join.StudentId == studentId));
      #nullable disable
      if (joinEntity == null && studentId != 0)
      {
        _db.StudentCourses.Add(new StudentCourse() { StudentId = studentId, CourseId = course.CourseId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = course.CourseId });
    } 
    public ActionResult Delete(int id)
    {
      Course thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Course thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
        StudentCourse joinEntry = _db.StudentCourses.FirstOrDefault(entry => entry.StudentCourseID == joinId);
        _db.StudentCourses.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    }
}
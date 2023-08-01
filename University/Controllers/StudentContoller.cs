using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
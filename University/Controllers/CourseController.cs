using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;

namespace University.Controllers
{
    public class CoursesController: Controller
    {
        private readonly UniversityContext _db;
        public CoursesController(UniversityContext db)
        {
            _db = db;
        }
    }
}
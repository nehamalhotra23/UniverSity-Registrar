using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace University.Controllers
{
     public class StudentController : Controller
    {
        private readonly UniversityContext _db;

        public StudentController(UniversityContext db)
        {
            _db = db;
        }
    public ActionResult Index()
    {
    return View(_db.Students.ToList());
    }
     public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
          .Include(Student => Student.Courses)
          .ThenInclude(join => join.Course)
          .FirstOrDefault(Student => Student.StudentId == id);
      return View(thisStudent);
    }
     public ActionResult DetailsOfDepartment(int id)
    {
      var thisStudentDept = _db.Students
          .Include(Student => Student.Departments)
          .ThenInclude(join => join.Department)
          .FirstOrDefault(Student => Student.StudentId == id);
      return View(thisStudentDept);
    }



    public ActionResult Create()
    {
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
        return View();
    }
   [HttpPost]
    public ActionResult Create(Student student, int CourseId)
    {
      _db.Students.Add(student);
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddCourse(int id)
    {
      var thisStudent= _db.Students.FirstOrDefault(s=> s.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult AddDepartment(int id)
    {
      var thisStudent= _db.Students.FirstOrDefault(s=> s.StudentId == id);
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddDepartment(Student student, int DepartmentId)
    {
      if (DepartmentId != 0)
      {
        _db.DepartmentStudent.Add(new DepartmentStudent() { DepartmentId = DepartmentId, StudentId = student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }









     public ActionResult Edit(int id)
    {
      var thisStudent= _db.Students.FirstOrDefault(s => s.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId= student.StudentId });
      }
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



}
}
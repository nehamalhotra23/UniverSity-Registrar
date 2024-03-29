using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace University.Controllers
{
  public class CourseController : Controller
  {
    private readonly UniversityContext _db;

    public CourseController(UniversityContext db)
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
      var thisCourse = _db.Courses
          .Include(course => course.Students)
          .ThenInclude(join => join.Student)
          .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }
    public ActionResult Edit(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
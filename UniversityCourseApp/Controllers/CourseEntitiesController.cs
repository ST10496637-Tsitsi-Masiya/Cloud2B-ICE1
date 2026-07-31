using Microsoft.AspNetCore.Mvc;
using UniversityCourseApp.Models;
using UniversityCourseApp.Services;

namespace UniversityCourseApp.Controllers
{
    public class CourseEntitiesController : Controller
    {
        private readonly TableStorageService storage;

        public CourseEntitiesController(TableStorageService storage)
        {
            this.storage = storage;
        }

        public IActionResult Index()
        {
            return View(storage.GetCourses());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CourseEntity course)
        {
            storage.AddCourse(course);

            return RedirectToAction("Index");
        }
    }
}

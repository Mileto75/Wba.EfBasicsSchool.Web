using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public CoursesController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        //show a list of courses
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //get the courses
            var courses = await _schoolDbContext
                .Courses.ToListAsync();
            //put in viewmodel
            var coursesIndexViewModel = new CoursesIndexViewModel
            {
                Courses  = courses
                .Select(c => new BaseViewModel 
                {
                    Id = c.Id,
                    Value = c.Name,
                })
            };
            //pass to the view
            return View(coursesIndexViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            //get the course
            var course = await _schoolDbContext.Courses
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(c => c.Id == id);
            _schoolDbContext?.Courses.Update(course);
            //check if null
            if (course == null)
            {
                return NotFound();
            }
            //fill the model
            var coursesInfoViewModel = new CoursesInfoViewModel
            {
                Course = new BaseViewModel 
                {
                    Id = course.Id,
                    Value = course.Name,
                },
                Teacher = new BaseViewModel 
                {
                    Id = course.Teacher.Id,
                    Value = $"{course.Teacher.Firstname} {course.Teacher.Lastname}"
                }
            };
            //pass to the view
            return View(coursesInfoViewModel);
        }
    }
}

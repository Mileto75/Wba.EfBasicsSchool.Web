using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentsController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public async Task<IActionResult> Index()
        {
            //show a list of students
            //get the students and put in model
            var studentsIndexViewModel = new StudentsIndexViewModel
            {
                Students = await _schoolDbContext
                .Students.Select(s => new BaseViewModel
                {
                    Id = s.Id,
                    Value = $"{s.Firstname} {s.Lastname}"
                }).ToListAsync()
            };
            return View(studentsIndexViewModel);
        }
    }
}

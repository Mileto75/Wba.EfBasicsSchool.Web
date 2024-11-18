using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Core.Entities;
using Wba.EfBasics.Web.Data;

namespace Wba.EfBasics.Web.Controllers
{
    public class CrudController : Controller
    {
        //declare dbContext
        private readonly SchoolDbContext _schoolDbContext;

        public CrudController(SchoolDbContext schoolDbContext)
        {
            //inject using constructor
            _schoolDbContext = schoolDbContext;
        }

        

        public async Task<IActionResult> Index()
        {
            var courses = await _schoolDbContext
                .Courses
                .ToListAsync();
            
            return View();
        }
        public async Task<IActionResult> Info(int id)
        {
            var course = await _schoolDbContext
                .Courses
                .Include(c => c.Students)
                .Include(c => c.Teacher)
                .ThenInclude(t => t.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
            
          return Content("Courses");
        }
        public async Task<IActionResult> Crud()
        {
            //add new student
            //var student = new Student();
            //student.Firstname = "Miles";
            //student.Lastname = "Davis";
            //student.Created = DateTime.Now;
            //add entity object to the change tracker
            //_schoolDbContext.Students.Add(student);
            //update student with id 5
            //get the student  = add to changetracker
            var student  = await _schoolDbContext
                .Students.FirstOrDefaultAsync(s => s.Id == 5);
            //change stuff
            student.Lastname = "Aspeslagh";
            student.Updated = DateTime.Now;
            //delete student with id = 5
            //get the student
            student = await _schoolDbContext.Students
                .FirstOrDefaultAsync(s => s.Id == 5);
            //mark for deletion
            _schoolDbContext.Students.Remove(student);
            //call savechangesAsync
            await _schoolDbContext.SaveChangesAsync();
            return Content("Added!");
        }
    }
}

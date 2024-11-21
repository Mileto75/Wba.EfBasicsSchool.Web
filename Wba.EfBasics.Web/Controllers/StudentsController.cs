using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Wba.EfBasics.Core.Entities;
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
        //Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //init viewmodel with courses
            var studentsAddViewModel = new StudentsAddViewModel
            {
                Courses = await _schoolDbContext
                .Courses.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToListAsync(),
            };
            return View(studentsAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(StudentsAddViewModel studentsAddViewModel)
        {
            //validate
            if(!ModelState.IsValid)
            {
                //return to the form
                studentsAddViewModel.Courses = await _schoolDbContext
                 .Courses.Select(s => new SelectListItem
                 {
                     Text = s.Name,
                     Value = s.Id.ToString()
                 }).ToListAsync();
                return View(studentsAddViewModel);
            }
            //save the new student to the database
            var newStudent = new Student
            {
                Firstname = studentsAddViewModel.Firstname,
                Lastname = studentsAddViewModel.Lastname,
                //get the courses based on coursesId's
                Courses = await _schoolDbContext
                        .Courses
                        .Where(c => studentsAddViewModel.CoursesId.Contains(c.Id))
                        .ToListAsync()
            };
            //add to tracking context/dbcontext
            _schoolDbContext.Add(newStudent);
            //saveschanges
            try 
            {
                await _schoolDbContext.SaveChangesAsync();
            }
            catch(DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.Message);
                return View(studentsAddViewModel);
            }
            //new student Added
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //get the student
            var editStudent = await _schoolDbContext
                .Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == id);
            //check if null
            if (editStudent == null)
            {
                return NotFound();
            }
            //student exists => fill the model
            var studentsEditViewModel = new StudentsEditViewModel
            {
                Firstname = editStudent.Firstname,
                Lastname = editStudent.Lastname,
                Courses = await _schoolDbContext
                .Courses.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToListAsync(),
                CoursesId = editStudent.Courses.Select(c => c.Id)
            };
            return View(studentsEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentsEditViewModel studentsEditViewModel)
        {
            //Validate
            if (!ModelState.IsValid)
            {
                studentsEditViewModel.Courses =
                await _schoolDbContext
                    .Courses
                    .Select(c => new SelectListItem 
                    {
                        Text= c.Name,
                        Value = c.Id.ToString()
                    }).ToListAsync();
                return View(studentsEditViewModel);
            }
            //check if student exists
            //if (!_schoolDbContext.Students.Any(
            //    s => s.Id == studentsEditViewModel.Id))
            //{
            //    return NotFound();
            //}
            var editStudent = await _schoolDbContext.Students
                .Include(studentsEditViewModel => studentsEditViewModel.Courses)
                .FirstOrDefaultAsync(s => s.Id == studentsEditViewModel.Id);
            if (editStudent == null)
            { 
                return NotFound();
            }
            //edit the student
            editStudent.Firstname = studentsEditViewModel.Firstname;
            editStudent.Lastname = studentsEditViewModel.Lastname;
            editStudent.Courses.Clear();
            editStudent.Courses = await _schoolDbContext
                        .Courses
                        .Where(c => studentsEditViewModel.CoursesId.Contains(c.Id))
                        .ToListAsync();
            editStudent.Updated = DateTime.Now;
            try
            {
                await _schoolDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.Message);
                return View(studentsEditViewModel);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            //check if exists
            var deleteStudent = await _schoolDbContext.Students
                .FirstOrDefaultAsync(s => s.Id == id);
            if(deleteStudent == null) 
            {
                return NotFound();
            }
            //fill the model
            var studentsDeleteViewModel = new StudentsDeleteViewModel
            {
                Id = deleteStudent.Id,
                Value = $"{deleteStudent.Firstname} {deleteStudent.Lastname}"
            };
            return View(studentsDeleteViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(StudentsDeleteViewModel studentsDeleteViewModel)
        {
            //get the student
            var deleteStudent = await _schoolDbContext
                   .Students.FirstOrDefaultAsync(s => s.Id == studentsDeleteViewModel.Id);
            if (deleteStudent == null)
            {
                return NotFound();
            }
            //delete the student => mark in change tracker
            _schoolDbContext.Students.Remove(deleteStudent);
            try
            {
                await _schoolDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

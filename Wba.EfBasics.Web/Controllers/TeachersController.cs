using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Core.Entities;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.Models;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    public class TeachersController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeachersController(SchoolDbContext schoolDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _schoolDbContext = schoolDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //fill the model with courses
            //send to the view
            var teachersAddViewModel = new TeachersAddViewModel
            {
                Courses = await _schoolDbContext
                .Courses.Select(c => new CheckboxModel 
                {
                    Id = c.Id,
                    Value = c.Name,
                }).ToListAsync()
            };
            return View(teachersAddViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TeachersAddViewModel teachersAddViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(teachersAddViewModel);
            }
            //create teacher
            //check for file 
            string filename = "";
               if (teachersAddViewModel.Image != null)
            {
                //create a unique filename
                filename =
                    $"{Guid.NewGuid()}_{teachersAddViewModel.Image.FileName}";
                //create path to folder
                var pathToImages = Path
                    .Combine(_webHostEnvironment.WebRootPath,"images");
                //check if folder exists
                if (!Directory.Exists(pathToImages))
                {
                    Directory.CreateDirectory(pathToImages);
                }
                //create the fullpath
                var fullPathToFile = Path.Combine(pathToImages, filename);
                //copy the file
                await using(FileStream fileStream = 
                    new FileStream(fullPathToFile,FileMode.Create))
                {
                    await teachersAddViewModel
                        .Image.CopyToAsync(fileStream);
                }
            }
            //create the teacher
            //get the selected courseIds
            var selectedCourses = teachersAddViewModel
                .Courses.Where(c => c.IsChecked == true)
                .Select(c => c.Id);
            var teacher = new Teacher 
            {
                Firstname = teachersAddViewModel.Firstname,
                Lastname = teachersAddViewModel.Lastname,
                Image = filename,
                Courses = await _schoolDbContext
                            .Courses
                            .Where(c => selectedCourses
                            .Contains(c.Id)).ToListAsync(),
                Created = DateTime.Now
            };
            //add to the context/tracker
            _schoolDbContext.Teachers.Add(teacher);
            //save to database
            try
            {
                await _schoolDbContext.SaveChangesAsync();
            }
            catch(DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.Message);
                return View(teachersAddViewModel);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

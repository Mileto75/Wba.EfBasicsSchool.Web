using Microsoft.AspNetCore.Mvc;
using Wba.EfBasics.Web.Data;

namespace Wba.EfBasics.Web.Controllers
{
    public class TeachersController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public TeachersController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}

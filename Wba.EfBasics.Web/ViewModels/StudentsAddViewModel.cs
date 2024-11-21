using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Wba.EfBasics.Web.ViewModels
{
    public class StudentsAddViewModel
    {
        [Required(ErrorMessage = "Firstname required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname required")]
        public string Lastname { get; set; }
        public string Address { get; set; }
        //multiple select list
        public IEnumerable<SelectListItem> Courses { get; set; }
        [Required(ErrorMessage = "Select at least one course!")]
        [Display(Name = "Courses")]
        public IEnumerable<int> CoursesId { get; set; }
    }
}

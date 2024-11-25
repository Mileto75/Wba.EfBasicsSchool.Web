using System.ComponentModel.DataAnnotations;
using Wba.EfBasics.Web.Models;

namespace Wba.EfBasics.Web.ViewModels
{
    public class TeachersAddViewModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public List<CheckboxModel> Courses { get; set; }
        public IFormFile Image { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Wba.EfBasics.Web.ViewModels
{
    public class StudentsEditViewModel : StudentsAddViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
    }
}

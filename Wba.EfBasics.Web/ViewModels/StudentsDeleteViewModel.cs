using Microsoft.AspNetCore.Mvc;

namespace Wba.EfBasics.Web.ViewModels
{
    public class StudentsDeleteViewModel : BaseViewModel
    {
        [HiddenInput]
        public new int Id { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Models
{
    public class CheckboxModel
    {
        public bool IsChecked { get; set; }
        [HiddenInput]
        public int Id { get; set; }
        [HiddenInput]
        public string Value { get; set; }
    }
}

using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public string Course { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

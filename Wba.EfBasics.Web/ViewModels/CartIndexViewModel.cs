using Wba.EfBasics.Web.Models;

namespace Wba.EfBasics.Web.ViewModels
{
    public class CartIndexViewModel
    {
        public List<CartItemModel> Items { get; set; }
        public decimal SubTotal { get; set; }
        public int Vat { get; set; }
        public decimal Total { get; set; }
    }
}

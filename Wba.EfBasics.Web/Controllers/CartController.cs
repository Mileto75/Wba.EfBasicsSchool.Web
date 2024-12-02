using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.Models;
using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public CartController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //shows cart from session
            //create viewmodel
            var cartIndexViewModel = new CartIndexViewModel
            {
                Items = new List<CartItemModel>(),
            };
            //check if cart in session
            if (HttpContext.Session.Keys.Contains("Cart"))
            {
                //get the list of items from session
                cartIndexViewModel.Items
                    = JsonConvert
                    .DeserializeObject<List<CartItemModel>>
                    (HttpContext.Session.GetString("Cart"));
            }
            //pass to the view
            return View(cartIndexViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            //adds item to cart in session
            //check if course exists
            var course = await _schoolDbContext
                .Courses
                .FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            //create the viewmodel
            var cartItems = new List<CartItemModel>();
            //check if session exists
            if(HttpContext.Session.Keys.Contains("Cart"))
            {
                //get the list of items from session
                cartItems
                    = JsonConvert
                    .DeserializeObject<List<CartItemModel>>
                    (HttpContext.Session.GetString("Cart"));
            }
            //no cart in session, add first product
            cartItems.Add(new CartItemModel 
            {
                Id = course.Id,
                Course = course.Name,
                Price = 50.00M,
                Quantity = 1
            });
            //store cartItems in session
            //serialize => store in session
            var serializedCartItems = JsonConvert.SerializeObject(cartItems);
            //store in session
            HttpContext.Session.SetString("Cart", serializedCartItems);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            //removes item from cart in session
            return RedirectToAction("Index");
        }
    }
}

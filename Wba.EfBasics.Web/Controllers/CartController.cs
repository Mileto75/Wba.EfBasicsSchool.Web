using Microsoft.AspNetCore.Http;
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
            //calculate total
            cartIndexViewModel.Items
                .ForEach(i => i.Total = i.Price * i.Quantity);
            cartIndexViewModel.Vat = 21;
            cartIndexViewModel.SubTotal = cartIndexViewModel.Items.Sum(i => i.Total);
            cartIndexViewModel.Total = cartIndexViewModel.SubTotal * (1 + cartIndexViewModel
                .Vat / 100M);
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
            //add product or increment quantity
            //check if course already in cart
            var item = cartItems.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cartItems.Add(new CartItemModel
                {
                    Id = course.Id,
                    Course = course.Name,
                    Price = 50.00M,
                    Quantity = 1
                });
            }
            //use the sum linq method to count the quantities in the list
            HttpContext.Session.SetInt32("NumOfItemsInCart",cartItems.Sum(c => c.Quantity));
            //store cartItems in session
            //serialize => store in session
            var serializedCartItems = JsonConvert.SerializeObject(cartItems);
            //store in session
            HttpContext.Session.SetString("Cart", serializedCartItems);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            //removes item from cart in session
            //check if cart in session
            if(!HttpContext.Session.Keys.Contains("Cart"))
            {
                return NotFound();
            }
            //check if courseid exists (use the any linq method)
            if(!await _schoolDbContext.Courses.AnyAsync(c => c.Id == id))
            {
                return NotFound();
            }
            //get the cartItems from session
            var cartItems = JsonConvert.DeserializeObject
                <List<CartItemModel>>(HttpContext.Session.GetString("Cart"));
            var item = cartItems.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            //check the quantity
            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                cartItems.Remove(item);
            }
            //put cart back in session
            //serialize
            var serializedCartItems = JsonConvert.SerializeObject(cartItems);
            //set the num of items
            HttpContext.Session.SetInt32("NumOfItemsInCart", cartItems.Sum(c => c.Quantity));
            //store in session
            HttpContext.Session.SetString("Cart", serializedCartItems);
            //redirect
            return RedirectToAction("Index");
        }
    }
}

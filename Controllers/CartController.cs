using AmazonWebsite.Areas.Admin.Models;
using AmazonWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AmazonWebsite.Helpers;
using Microsoft.AspNetCore.Http;

namespace AmazonWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly AmazonContext _context;

        public CartController(AmazonContext context)
        {
            _context = context;
        }
   
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(Setting.Cart_key) ?? new List<CartItem>();

        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(int id, int quantity =1)
        {
            var mCart = Cart;
            var item = mCart.SingleOrDefault(p => p.ProductId == id);
            if (item == null) 
            { 
                var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
                if(product == null)
                {
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    ProductId = product.ProductId,
                    Image = product.Image ?? string.Empty,
                    ProductName = product.ProductName,
                    Price = product.Price ?? 0,
                    Quantity = quantity
                };
                mCart.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            HttpContext.Session.Set<List<CartItem>>(Setting.Cart_key, mCart);

            return RedirectToAction("index");
        }

        public IActionResult RemovefromCart(int id) 
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.Set<List<CartItem>>(Setting.Cart_key, cart);

            }

            return RedirectToAction("index");
        }
     
    }
}

using AmazonWebsite.Areas.Admin.Models;
using AmazonWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AmazonWebsite.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
       
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = Cart;
            if(cart.Count == 0)
            {
                return Redirect("/");
            } 
            return View(cart);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(CheckoutVM model)
        {

                if (ModelState.IsValid)
            {
               var customerID =  HttpContext.User.Claims.SingleOrDefault(p => p.Type == Setting.CLAIM_CUSTOMERID).Value;
                var customer = new Customer();
                if (model.Sameinformation)
                {
                    customer = _context.Customers.SingleOrDefault(cus => cus.CustomerId == customerID);
                }
                var bill = new Order
                {
                    CustomerId = customerID,
                    Name = model.FullName ?? customer.Name,
                    Address = model.Address ?? customer.Address,

                    BuyingDate = DateTime.Now,
                    PaymentMethod = "COD",
                    DeliveryMethod = "SHIPPER",
                    StatusId = 0,
                    Note = model.Note
                };
                _context.Database.BeginTransaction();
                try
                {
                    _context.Database.CommitTransaction();
                    _context.Add(bill);
                    _context.SaveChanges();

                    var orderdetail = new List<OrderDetail>();
                    foreach (var item in Cart)
                    {
                        orderdetail.Add(new OrderDetail
                        {
                           
                            OrderId = bill.OrderId,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            ProductId = item.ProductId
                        });
                    }
                    _context.AddRange(orderdetail);
                    _context.SaveChanges();
                    
                    HttpContext.Session.Set<List<CartItem>>(Setting.Cart_key,new List<CartItem>());

                    return View("Success");
                }
                
                catch
                {
                    _context.Database.RollbackTransaction();
                }

            }
            return View();
        }
    }
}

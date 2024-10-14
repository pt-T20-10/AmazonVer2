using AmazonWebsite.Helpers;
using AmazonWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AmazonWebsite.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(Setting.Cart_key) ?? new List<CartItem>();

            return View("CartPanel", new CartModel
            {
                Quantity = cart.Sum(x => x.Quantity),
                Total = cart.Sum(x => x.TotalPrice)
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using AmazonWebsite.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using AmazonWebsite.ViewModels;

namespace AmzonCloneWebsite.Controllers
{
    public class CustomerProductController : Controller
    {
        private readonly AmazonContext _context;

        public CustomerProductController(AmazonContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var products = _context.Products.AsQueryable();
            if (id.HasValue)
            {
                products = products.Where(p => p.TypeId ==id);
            }
            var result = products.Select(p => new ProductVM
            {
                ProducID = p.ProductId,
                ProductName = p.ProductName,
                Image = p.Image ?? "",
                Price = p.Price ?? 0,
                ShortDescription = p.Unit ?? "",
                TypeName = p.Type.TypeName
            });
            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var products = _context.Products.AsQueryable();
            if (query != null)
            {
                products = products.Where(p => p.ProductName.Contains(query));
            }
            var result = products.Select(p => new ProductVM
            {
                ProducID = p.ProductId,
                ProductName = p.ProductName,
                Image = p.Image ?? "",
                Price = p.Price ?? 0,
                ShortDescription = p.Unit ?? "",
                TypeName = p.Type.TypeName
            });
            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var data = _context.Products
                .Include(p => p.Type)
                .SingleOrDefault(p => p.ProductId == id);

            if (data == null)
            {
                TempData["Message"] = $"Cannot find product with code: {id}";
                return Redirect("/404");
            }
            var result = new ProductDetailVM
            {
                ProducID = data.ProductId,
                ProductName = data.ProductName,
                Image = data.Image ?? "",
                Price = data.Price ?? 0,
                ShortDescription = data.Unit ?? string.Empty,
                Details = data.Description,
                Rating = 5,
                TypeName = data.Type.TypeName,
                SoluongTon = 10

            };
            return View(result);
        }
    }


}

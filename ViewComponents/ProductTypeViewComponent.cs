using AmazonWebsite.Areas.Admin.Models;
using AmazonWebsite.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmazonWebsite.ViewComponents
{
    public class ProductTypeViewComponent : ViewComponent
    {
        private readonly AmazonContext _context;

        public ProductTypeViewComponent(AmazonContext context) => _context = context;

        public IViewComponentResult Invoke()
        {
            var data = _context.ProductTypes.Select(ProType => new ProductTypeVM
            {
                ProductTypeID = ProType.TypeId,

                ProductTypeName = ProType.TypeName,

                TypeQuantity = ProType.Products.Count

            });
            return View(data);
        }

    }

}

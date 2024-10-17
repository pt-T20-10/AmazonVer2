using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmazonWebsite.Areas.Admin.Models;

namespace AmazonWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        private readonly AmazonContext _context;

        public AdminProductController(AmazonContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminProduct
        public async Task<IActionResult> Index()
        {
            var amazonContext = _context.Products.Include(p => p.Type);
            return View(await amazonContext.ToListAsync());
        }

        // GET: Admin/AdminProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/AdminProduct/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.ProductTypes, "TypeId", "TypeId");
            return View();
        }

        // POST: Admin/AdminProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,AliasName,TypeId,Unit,Price,Image,Description")] Product product, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Tạo đường dẫn để lưu file
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Hinh/Hinh/HangHoa", ImageFile.FileName);

                    // Lưu file vào server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    // Cập nhật đường dẫn hình ảnh vào thuộc tính Image
                    product.Image = ImageFile.FileName;
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.ProductTypes, "TypeId", "TypeId", product.TypeId);
            return View(product);
        }

        // GET: Admin/AdminProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.ProductTypes, "TypeId", "TypeId", product.TypeId);
            return View(product);
        }

        // POST: Admin/AdminProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       // POST: Admin/AdminProduct/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,AliasName,TypeId,Unit,Price,Image,Description")] Product product, IFormFile ImageFile)
{
    if (id != product.ProductId)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Tạo đường dẫn để lưu file
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Hinh/Hinh/HangHoa", ImageFile.FileName);

                // Lưu file vào server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Cập nhật đường dẫn hình ảnh vào thuộc tính Image
                product.Image = ImageFile.FileName;
            }

            _context.Update(product);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(product.ProductId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    ViewData["TypeId"] = new SelectList(_context.ProductTypes, "TypeId", "TypeId", product.TypeId);
    return View(product);
}


        // GET: Admin/AdminProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/AdminProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}

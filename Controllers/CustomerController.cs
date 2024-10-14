using Microsoft.AspNetCore.Mvc;
using AmazonWebsite.Areas.Admin.Models;
using AmazonWebsite.ViewModels;
using AutoMapper;
using AmazonWebsite.Helpers;

namespace AmazonWebsite.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AmazonContext _context;

        private readonly IMapper _mapper;

        public CustomerController(AmazonContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customer = _mapper.Map<Customer>(model);
                    customer.RandomKey = MyUtil.GenerateRandomKey();
                    customer.Password = model.Password.ToMd5Hash(customer.RandomKey);
                    customer.Validation = true; //dung` mail de active
                    customer.Role = 0;

                    if (Image != null)
                    {
                        customer.Image = MyUtil.UploadImage(Image, model.Image);
                    }
                    _context.Add(customer);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "CustomerProduct");
                }
                catch
                {
                    // Xử lý lỗi tại đây (nếu cần)
                }
            }

            // Trả về view với model trong trường hợp lỗi hoặc không hợp lệ
            return View(model);
        }


    }
}
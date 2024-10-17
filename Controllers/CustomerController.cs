using Microsoft.AspNetCore.Mvc;
using AmazonWebsite.Areas.Admin.Models;
using AmazonWebsite.ViewModels;
using AutoMapper;
using AmazonWebsite.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

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
        #region Register
            
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model, IFormFile? Image)
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
                    return RedirectToAction("Index", "CustomerHome");
                }
                catch (Exception ex)
                {
                    var mess = $"{ex.Message} shh";
                }
            }
                // Trả về view với model trong trường hợp lỗi hoặc không hợp lệ
                return View();
        }
        #endregion
        #region Login
        [HttpGet]
        public IActionResult Login(string? ReturnUrl) 
        {
            ViewBag.ReturnUrl = ReturnUrl.Trim();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl) 
        {

            ViewBag.ReturnUrl = ReturnUrl.Trim();
            if (ModelState.IsValid) 
            {
                var customer = _context.Customers.SingleOrDefault(cus => 
                        cus.CustomerId == model.UserName);
                if (customer == null)
                {
                    ModelState.AddModelError("error", "Tài khoản hoặc mật khẩu không đúng");
                }
                else
                {
                    if (!customer.Validation)
                    {
                        ModelState.AddModelError("error", "Tài khoản này đã bị khóa. Vui lòng liên hệ bộ phận hỗ trợ khách hàng");
                    }
                    else
                    {
                        if(customer.Password != model.Password.ToMd5Hash(customer.RandomKey))
                        {
                            ModelState.AddModelError("error", "Tài khoản hoặc mật khẩu không đúng");
                        }
                        else 
                        {
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Email, customer.Email),
                                new Claim(ClaimTypes.Name, customer.Name),
                                new Claim(Setting.CLAIM_CUSTOMERID, customer.CustomerId),
                            };
                            var claimsIdentity = new ClaimsIdentity(claims,"Login");
                            var claimsPrincipal  = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimsPrincipal);
                            if (Url.IsLocalUrl(ReturnUrl)) 
                            {
                                return Redirect(ReturnUrl);  
                            }
                            else 
                            {
                                return Redirect("/");
                            } 
                                
                        } 
                            
                    }    
                }
            }
            return View();
        }
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        #endregion
        [Authorize]
        public async Task<IActionResult> Logout()
        { 
            await HttpContext.SignOutAsync();    
            return Redirect("/");
        }

    }
}
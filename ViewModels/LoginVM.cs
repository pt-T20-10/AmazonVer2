using System.ComponentModel.DataAnnotations;
namespace AmazonWebsite.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Vui lòng nhập tài khoản") ]
        [MaxLength(20, ErrorMessage ="Tên đăng nhập tối đa 20 kí tự")]
        public required string UserName { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace AmazonWebsite.ViewModels
{
    public class LoginVN
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="*") ]
        [MaxLength(20, ErrorMessage ="Tên đăng nhập tối đa 20 kí tự")]
        public string UserName { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

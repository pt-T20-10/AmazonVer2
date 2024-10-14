using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.ViewModels
{
    public class RegisterVM
    {
        [Key]
        [Display(Name = "User Name")]
        [Required(ErrorMessage ="*")]
        [MaxLength(20,ErrorMessage ="Tên đăng nhập tối đa 20 kí tự")]
        public string CustomerId { get; set; }

        [Display(Name="Password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Họ và tên tối đa 50 kí tự")]
        public string Name { get; set; }

        [Display(Name="Gender")]
        public bool Sex { get; set; } = true;

        [Display(Name = "Day of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Address")]
        [MaxLength(60, ErrorMessage ="Địa chỉ tối đa 60 kí tự")]
        public string? Address { get; set; }

        [Display(Name = "Phone")]
        [MaxLength(24, ErrorMessage = "Số điện tối đa 24 kí tự")]
        [RegularExpression("^(0|\\+84)(3[2-9]|5[6|8|9]|7[0|6|7|8|9]|8[1-6|8-9]|9[0-9])[0-9]{7}$", ErrorMessage ="Số điện thoại không hợp lệ")] //Check số điện thoại Việt Nam
        public string? PhoneNumbers { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email này không phù hợp")]
        public string Email { get; set; } 


        public string? Image { get; set; }
    }
}

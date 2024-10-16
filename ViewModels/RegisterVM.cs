using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.ViewModels
{
    public class RegisterVM
    {
        [Key]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "*")]
        [MaxLength(20, ErrorMessage = "Tên đăng nhập tối đa 20 kí tự")]
        public string CustomerId { get; set; } = null!; 

        [Display(Name="Password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Họ và tên tối đa 50 kí tự")]
        public string Name { get; set; } =null!;

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
        [RegularExpression(@"0[9875]\d{8}", ErrorMessage = "Chưa đúng định dạng di động Việt Nam")] //Check số điện thoại Việt Nam
        public string? PhoneNumbers { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email này không phù hợp")]
        public string Email { get; set; } = null!;


        public string? Image { get; set; }
    }
}

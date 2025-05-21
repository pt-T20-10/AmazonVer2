using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class Favorite
    {
        [Key] // Đánh dấu thuộc tính là khóa chính
        public int FavoriteId { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "CustomerId is required.")]
        public string? CustomerId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Choosing Date")]
        public DateTime? ChoosingDate { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual Product? Product { get; set; }
    }
}

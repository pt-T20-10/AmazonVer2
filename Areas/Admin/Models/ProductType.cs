using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class ProductType
    {
        [Key] // Đánh dấu thuộc tính là khóa chính
        public int TypeId { get; set; }

        [Required(ErrorMessage = "TypeName is required.")]
        [StringLength(100, ErrorMessage = "TypeName cannot exceed 100 characters.")]
        public string TypeName { get; set; } = null!;

        [StringLength(100, ErrorMessage = "TypeAliasName cannot exceed 100 characters.")]
        public string? TypeAliasName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public string? Image { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

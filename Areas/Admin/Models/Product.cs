using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonWebsite.Areas.Admin.Models
{
    public partial class Product
    {
        [Key] // Đánh dấu thuộc tính là khóa chính
        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required.")]
        [StringLength(100, ErrorMessage = "ProductName cannot exceed 100 characters.")]
        public string ProductName { get; set; } = null!;

        [StringLength(100, ErrorMessage = "AliasName cannot exceed 100 characters.")]
        public string? AliasName { get; set; }

        [Required(ErrorMessage = "TypeId is required.")]
        public int TypeId { get; set; }

        [StringLength(50, ErrorMessage = "Unit cannot exceed 50 characters.")]
        public string? Unit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public double? Price { get; set; }

        public string? Image { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ProductType Type { get; set; } = null!;
    }
}
